using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialActive : MonoBehaviour
{
    public Collider player;
    public GameObject tutorial;
    void OnTriggerStay(Collider player) //Appropriate hud element becomes active when player is in trigger
    {
        tutorial.SetActive(true);
    }

    private void OnTriggerExit(Collider other) //Removes hud element when player leaves trigger
    {
        tutorial.SetActive(false);
    }
}