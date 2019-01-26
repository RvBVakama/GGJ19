using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using UnityEngine.PostProcessing;

public class Manager : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController rbfpc;
    public PostProcessingProfile ppp = null;

    public Camera camMain = null;
    public Camera camLerp = null;
    public Camera camMenu = null;

    public Canvas canMenu = null;
    public Canvas canEditUI = null;
    public BGCcTrs trs = null;
    public static bool sbPaused = true;

    public bool bFlyToPlayer = false;
    public bool bFlyToMenu = false;

    private Vector3 v3StartPos;
    private Vector3 v3StartRot;

    private Vector3 v3EndPos;
    private Vector3 v3EndRot;

    DepthOfFieldModel.Settings dof;


    private void Start()
    {
        dof = ppp.depthOfField.settings;
        rbfpc.enabled = false;
        sbPaused = true;
    }

    private void Update()
    {
        Pause();
        FlyToPlayer();
        FlyToMenu();
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

        v3StartPos = camMenu.transform.localPosition;
        v3StartRot = camMenu.transform.localEulerAngles;

        v3EndPos = camMain.transform.position;
        v3EndRot = camMain.transform.eulerAngles;

        camMenu.gameObject.SetActive(false);
        camLerp.gameObject.SetActive(true);
    }

    float fCount = 0.0f;
    float fFlyTime = 5.0f;

    private void FlyToPlayer()
    {
        if (bFlyToPlayer)
            if (fCount < fFlyTime)
            {
                fCount += Time.deltaTime;

                // reduce dof over time
                dof.focalLength = Mathf.Lerp(22.0f, 14.0f, fCount / fFlyTime);
                ppp.depthOfField.settings = dof;

                camLerp.transform.localPosition = Vector3.Lerp(v3StartPos, v3EndPos, fCount / fFlyTime);
                //camMain.transform.eulerAngles = Vector3.Lerp(v3StartRot, v3EndRot, fCount / fFlyTime);
                camLerp.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(v3StartRot.x, v3EndRot.x, fCount / fFlyTime), Mathf.LerpAngle(v3StartRot.y, v3EndRot.y, fCount / fFlyTime), Mathf.LerpAngle(v3StartRot.z, v3EndRot.z, fCount / fFlyTime));
            }
            else
            {
                fCount = 0.0f;

                camLerp.gameObject.SetActive(false);
                camMain.gameObject.SetActive(true);

                rbfpc.enabled = true;
                sbPaused = false;
                bFlyToPlayer = false;
            }
    }

    private void FlyToMenu()
    {
        if (bFlyToMenu)
            if (fCount < fFlyTime)
            {
                fCount += Time.deltaTime;

                // reduce dof over time
                dof.focalLength = Mathf.Lerp(14.0f, 22.0f, fCount / fFlyTime);
                ppp.depthOfField.settings = dof;

                camLerp.transform.localPosition = Vector3.Lerp(v3StartPos, v3EndPos, fCount / fFlyTime);
                //camMain.transform.eulerAngles = Vector3.Lerp(v3StartRot, v3EndRot, fCount / fFlyTime);
                camLerp.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(v3StartRot.x, v3EndRot.x, fCount / fFlyTime), Mathf.LerpAngle(v3StartRot.y, v3EndRot.y, fCount / fFlyTime), Mathf.LerpAngle(v3StartRot.z, v3EndRot.z, fCount / fFlyTime));
            }
            else
            {
                fCount = 0.0f;

                camLerp.gameObject.SetActive(false);
                camMain.gameObject.SetActive(false);
                camMenu.gameObject.SetActive(true);

                sbPaused = false;
                bFlyToMenu = false;
            }
    }

    public void Pause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
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
                //trs.ObjectToManipulate = camMain.transform;

                rbfpc.enabled = false;
                sbPaused = true;
                bFlyToMenu = true;

                v3StartPos = camMain.transform.position;
                v3StartRot = camMain.transform.eulerAngles;

                v3EndPos = camMenu.transform.position;
                v3EndRot = camMenu.transform.eulerAngles;

                camMain.gameObject.SetActive(false);
                camLerp.gameObject.SetActive(true);
            }

            sbPaused = !sbPaused;
        }
    }

    public void Leave()
    {
        Application.Quit();
    }

}
