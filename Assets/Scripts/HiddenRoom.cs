using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenRoom : MonoBehaviour
{
    public static GameObject goTrapdoor = null;
    public GameObject pictureStorage = null;
    public AudioClip audDoorOpen = null;
    public AudioSource audSrcPlayer = null;


    private KeyCode[] konamiCode = { KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A, KeyCode.Return };
    private void Start()
    {
        goTrapdoor = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        KonamiCode();
    }

    public static int nKonamiCodeProgress = 0;

    private void KonamiCode()
    {
        // release hidden barrier
        if (nKonamiCodeProgress > konamiCode.Length - 1)
        {
            Debug.Log("correct!");
            goTrapdoor.transform.gameObject.SetActive(false);
            nKonamiCodeProgress = 0;
            audSrcPlayer.PlayOneShot(audDoorOpen);
            AddRbToPics();
            return;
        }

        // if the correct input is entered
        if (Input.GetKeyUp(konamiCode[nKonamiCodeProgress]))
        {
            // got one right so progress
            ++nKonamiCodeProgress;
            Debug.Log(nKonamiCodeProgress);
        }
    }

    private void AddRbToPics()
    {
        RawImage[] goArr = pictureStorage.transform.GetComponentsInChildren<RawImage>();

        foreach (RawImage go in goArr)
        {
            go.gameObject.AddComponent<Rigidbody>();
        }
    }
}
