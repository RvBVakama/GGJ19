using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangePhoto : MonoBehaviour
{
    public Texture[] frames;

    public string url = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Banana-Single.jpg/1200px-Banana-Single.jpg";
    public void Img()
    {
        using (WWW www = new WWW(url))
        {
            if (www.isDone)
                System.IO.File.WriteAllBytes(@"L:\rwr\bababal.jpg", www.bytes);
        }
    }


    public void Awake()
    {
        Object[] textures = Resources.LoadAll("Images/Stupendious", typeof(Texture2D));
        frames = new Texture[textures.Length];

        for (int i = 0; i < textures.Length; i++)
        {
            frames[i] = (Texture)textures[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        CyclePhoto();
        Img();
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
    }

    int nImgChoice = 0;

    public void Cycle(RaycastHit hit)
    {
        RawImage Ri;

        if (Ri = hit.transform.GetComponent<RawImage>())
        {
            // if mouse button left
            if (Input.GetMouseButtonDown(0))
            {
                ++nImgChoice;
                if (nImgChoice > frames.Length - 1)
                    nImgChoice = 0;
                Ri.texture = frames[nImgChoice];
                Ri.GetComponent<AspectRatioFitter>().aspectRatio = (float)Ri.texture.width / (float)Ri.texture.height;
            }

            // if mouse button right
            if (Input.GetMouseButtonDown(1))
            {
                --nImgChoice;
                // cycle back to the top of the 
                if (nImgChoice < 0)
                    nImgChoice = frames.Length - 1;

                Ri.texture = frames[nImgChoice];
                Ri.GetComponent<AspectRatioFitter>().aspectRatio = (float)Ri.texture.width / (float)Ri.texture.height;
            }
        }

    }
}

