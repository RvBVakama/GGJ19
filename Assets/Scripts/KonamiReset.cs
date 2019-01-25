using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonamiReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // close the trap door again
        HiddenRoom.goTrapdoor.transform.gameObject.SetActive(true);
        HiddenRoom.nKonamiCodeProgress = 0;
    }
}
