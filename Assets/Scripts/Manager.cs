using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;

public class Manager : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController rbfpc;
    public Camera camMain = null;
    public Canvas canMenu = null;
    public Canvas canEditUI = null;
    public BGCcTrs trs = null;
    public static bool sbPaused = true;

    public bool bFlyToPlayer = false;
    public bool bFlyToMenu = false;

    private Vector3 v3StartPos;
    private Vector3 v3StartRot;

    private Vector3 v3EndPos = new Vector3(0.0f, 0.6f, 0.0f);
    private Vector3 v3EndRot = new Vector3(0.0f, 0.0f, 0.0f);


    private void Start()
    {
        rbfpc.enabled = false;
        sbPaused = true;
    }

    private void Update()
    {
        Pause();
        FlyToPlayer();
    }

    public void Enter()
    {
        // turn off the menu objects
        canMenu.gameObject.SetActive(false);

        // get rid of the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // enable the edit UI
        canEditUI.gameObject.SetActive(true);

        // Unassign the camera from the trs component
        trs.ObjectToManipulate = null;

        bFlyToPlayer = true;

        v3StartPos = camMain.transform.position;
        v3StartRot = camMain.transform.eulerAngles;
    }

    float fCount = 0.0f;
    float fFlyTime = 5.0f;

    private void FlyToPlayer()
    {
        if (bFlyToPlayer)
            if (fCount < fFlyTime)
            {
                fCount += Time.deltaTime;
                camMain.transform.position = Vector3.Lerp(v3StartPos, v3EndPos, fCount / fFlyTime);
                camMain.transform.eulerAngles = new Vector3(v3EndRot.x, v3EndRot.y, v3EndRot.z);
            }
            else
            {
                fCount = 0.0f;
                camMain.transform.position = v3EndPos;

                rbfpc.enabled = true;
                sbPaused = false;
                bFlyToPlayer = false;
            }
    }

    public void Pause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            sbPaused = !sbPaused;

            if (!sbPaused)
            {
                // turn off the menu objects
                canMenu.gameObject.SetActive(true);

                // get rid of the cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // enable the edit UI
                canEditUI.gameObject.SetActive(false);

                // Unassign the camera from the trs component
                trs.ObjectToManipulate = camMain.transform;

                rbfpc.enabled = false;
                sbPaused = true;
            }
        }
    }

    public void Leave()
    {
        Application.Quit();
    }

}
