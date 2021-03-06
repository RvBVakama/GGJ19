﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUp : MonoBehaviour
{
    public GameObject playerGO = null;

    private void OnTriggerEnter(Collider col)
    {
        // close the trap door again
        col.GetComponent<Rigidbody>().AddForce(Vector3.up  * 185, ForceMode.Impulse);

        Manager.bSandEnter = true;
    }
}
