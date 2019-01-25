using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : MonoBehaviour
{
    public GameObject goTrapdoor = null;

    private KeyCode[] konamiCode = { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A, KeyCode.Return };

    // Update is called once per frame
    void Update()
    {
        KonamiCode();
    }

    int nKonamiCodeProgress = 0;

    private void KonamiCode()
    {
        // release hidden barrier
        if (nKonamiCodeProgress > konamiCode.Length - 1)
        {
            Debug.Log("correct!");
            goTrapdoor.transform.GetComponent<BoxCollider>().enabled = false;
            nKonamiCodeProgress = 0;
            return;
        }

        if (Input.anyKeyDown)
        {
            // if the correct input is entered
            if (Input.GetKeyUp(konamiCode[nKonamiCodeProgress]))
            {
                // got one right so progress
                ++nKonamiCodeProgress;
                Debug.Log(nKonamiCodeProgress);
            }
            // got a sequence wrong back to the start
            else if (!Input.GetKeyUp(konamiCode[nKonamiCodeProgress]))
            {
                Debug.Log("wrong");
            }
        }
    }
}
