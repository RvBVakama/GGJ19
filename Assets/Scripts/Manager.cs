using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Canvas canMenu = null;
    public Camera camMenu = null;
    

    public void Enter()
    {
        // turn off the menu objects
        canMenu.gameObject.SetActive(false);
        camMenu.gameObject.SetActive(false);

        // get rid of the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Leave()
    {
        Application.Quit();
    }
}
