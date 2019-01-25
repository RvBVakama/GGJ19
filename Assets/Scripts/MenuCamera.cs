using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public GameObject target = null;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);
    }
}
