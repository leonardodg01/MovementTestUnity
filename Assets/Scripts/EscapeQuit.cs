using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeQuit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Quits game if player presses Esc
            Application.Quit();
    }
}
