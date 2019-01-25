using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : MonoBehaviour
{
    private KeyCode[] konamiCode = { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A, KeyCode.Return };

    // Update is called once per frame
    void Update()
    {
        KonamiCode();
    }

    int nKonamiCodeProgress = 0;

    private void KonamiCode()
    {
        // if the correct input is entered
        if (Input.GetKeyUp(konamiCode[nKonamiCodeProgress]))
        {
            // release hidden barrier
            if (nKonamiCodeProgress > konamiCode.Length)
            {

            }

            // got one right so progress
            ++nKonamiCodeProgress;
            Debug.Log(nKonamiCodeProgress);
        }
        // got a sequence wrong back to the start
        else if (Input.anyKeyUp)
            nKonamiCodeProgress = 0;
    }
}
