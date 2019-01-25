using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePhoto : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        ChangePicture();
    }

    public void ChangePicture()
    {
        // if mouse button left or right
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Photo")
                {
                    // if mouse button left
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("changeleft");
                    }

                    // if mouse button right
                    if (Input.GetMouseButtonDown(1))
                    {
                        Debug.Log("changeright");
                    }
                }
            }
        }
        //RawImage ri;
        //ri.mainTexture.width
    }
}

