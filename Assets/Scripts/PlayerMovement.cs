using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //Controller for player
    public GameObject player;

    public float movementSpeed = 5f;
    public float sprintSpeed = 1.05f;
    public float crouchSpeed = 0.5f;
    public float jumpHeight = 5f;
    private float playerHeight;
    public const float gravity = -9.81f;
    
    private bool grounded; //True if player is touching ground
    
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        playerHeight = controller.height; //Saves the players size
    }

    // Update is called once per frame
    void Update()
    {
        float getHorizontal = Input.GetAxis("Horizontal");
        float getVertical = Input.GetAxis("Vertical");

        Debug.DrawRay(player.transform.localPosition, Vector3.down * (player.transform.localScale.y*1.2f), Color.white, 0f, true); //Draw ground raycast to scene view
        Debug.DrawRay(player.transform.localPosition, Vector3.up * (player.transform.localScale.y * 1.2f), Color.white, 0f, true); //Draw wall raycast to scene view
        if (Physics.Raycast(player.transform.localPosition, Vector3.down, player.transform.localScale.y*1.2f, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore)) //Detects if touching ground
        {
            grounded = true;
            Debug.Log("Grounded"); //This message must display if player is touching the ground

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

        }
        else //If player not touching ground, gravity affects it
        {
            velocity.y += gravity * Time.deltaTime; //fall speed
            grounded = false;
        }

        Vector3 move = transform.right * getHorizontal + transform.forward * getVertical; //Gives the move vector the inputs from keyboard

        if (Input.GetKey(KeyCode.LeftShift) && grounded == true) //Applies sprint multiplier if left shift is pressed and touching ground
        {
            //Debug.Log("Sprinting");
            controller.Move(move * movementSpeed * sprintSpeed * Time.deltaTime); //Applies directional movement
        }
        else if //Shrinks player and applies crouch multiplier if left ctrl is pressed
        (Input.GetKey(KeyCode.LeftControl) && grounded == true && grounded == true)
        {
            controller.Move(move * movementSpeed * crouchSpeed * Time.deltaTime);
            controller.height /= 2; //Halves the height of player
        }
        else if (!Physics.Raycast(player.transform.localPosition, Vector3.up, player.transform.localScale.y * 1.2f, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore)) //Checks if roof is present
        {
            controller.Move(move * movementSpeed * Time.deltaTime);
            controller.height = playerHeight; //Player's original size
        }

        controller.Move(velocity * Time.deltaTime); //Applies upward and downward velocity
    }
}
