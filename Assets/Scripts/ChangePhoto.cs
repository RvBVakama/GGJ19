using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangePhoto : MonoBehaviour
{
    public Camera camMain = null;
    public Texture2D[] frames;
    public AudioClip[] sfxChimes;
    public AudioSource audSource;

    public void Awake()
    {
        UpdatePhotos();

        //Object[] textures = Resources.LoadAll("Images/Stupendious", typeof(Texture2D));
        //frames = new Texture[textures.Length];

        //for (int i = 0; i < textures.Length; i++)
        //{
        //    frames[i] = (Texture)textures[i];
        //}
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
            if (camMain.gameObject.activeInHierarchy)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Cycle(hit);
                }
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
                if (nImgChoice > frames.Length - 1)
                    nImgChoice = 0;
                Ri.texture = frames[nImgChoice];
                Ri.GetComponent<AspectRatioFitter>().aspectRatio = (float)Ri.texture.width / (float)Ri.texture.height;
                PlayChime(hit);
                ++nImgChoice;
            }

            // if mouse button right
            if (Input.GetMouseButtonDown(1))
            {
                // cycle back to the top of the 
                if (nImgChoice < 0)
                    nImgChoice = frames.Length - 1;

                Ri.texture = frames[nImgChoice];
                Ri.GetComponent<AspectRatioFitter>().aspectRatio = (float)Ri.texture.width / (float)Ri.texture.height;
                PlayChime(hit);
                --nImgChoice;
            }
        }

    }

    public void PlayChime(RaycastHit hit)
    {
        int rdm = Random.Range(0, sfxChimes.Length);
        //audSource.transform.SetPositionAndRotation(hit.transform.position, hit.transform.rotation);
        audSource.PlayOneShot(sfxChimes[rdm]);
    }

    string[] strFilenames;
    string pathPrefix = @"file://";
    string path = @"YourPhotos\";

    public void UpdatePhotos()
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        // Initialize the temporary filename array. 
        strFilenames = new string[Directory.GetFiles(path).Length];

        // Put the path to the files in this array.
        strFilenames = Directory.GetFiles(path);

        if (strFilenames.Length > 0)
        {
            frames = new Texture2D[strFilenames.Length];

            for (int i = 0; i < strFilenames.Length; i++)
            {
                //Debug.Log(pathPrefix + Directory.GetCurrentDirectory() + "\\" + strFilenames[i]);
                WWW www = new WWW(pathPrefix + Directory.GetCurrentDirectory() + "\\" + strFilenames[i]);
                Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT1, false);
                //LoadImageIntoTexture compresses JPGs by DXT1 and PNGs by DXT5     
                www.LoadImageIntoTexture(texTmp);
                frames[i] = texTmp;
            }
        }
        // No photos found.
    }
}

