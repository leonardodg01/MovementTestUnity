using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{

    public Animator buttonAnimation;
    public Collider playerCollider;

    private IEnumerator OnTriggerStay(Collider playerCollider)
    {
        if (Input.GetKey(KeyCode.E))
        {
            buttonAnimation.SetTrigger("PlayerInteract");
            Debug.Log("Pressed button!");

            yield return new WaitForSeconds(1); //Sends player to menu after 1 second
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
