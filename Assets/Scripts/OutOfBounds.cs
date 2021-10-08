using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public Collider playerCollider;

    private void OnTriggerEnter(Collider playerCollider) //Reloads scene when player collides with bottom of map
    {
        SceneManager.LoadScene("MainGame");
    }
}
