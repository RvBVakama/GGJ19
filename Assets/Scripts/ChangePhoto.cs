using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangePhoto : MonoBehaviour
{
    public Texture[] frames;

    public void Start()
    {
        frames = new Texture[100];
        Object[] textures = Resources.LoadAll("Images", typeof(Texture2D));

        for (int i = 0; i < textures.Length; i++)
        {
            frames[i] = (Texture)textures[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        CyclePhoto();
    }

    public void CyclePhoto()
    {
        // if mouse button left or right
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Cycle(hit);
            }
        }
        //RawImage ri;
        //ri.mainTexture.width
    }

    public void Cycle(RaycastHit hit)
    {
        RawImage Ri;

        if (Ri = hit.transform.GetComponent<RawImage>())
        {
            // if mouse button left
            if (Input.GetMouseButtonDown(0))
            {
                Ri.texture = frames[0];
                Ri.GetComponent<AspectRatioFitter>().aspectRatio = Ri.texture.width / Ri.texture.height;
            }

            // if mouse button right
            if (Input.GetMouseButtonDown(1))
            {

            }
        }
    }
}

