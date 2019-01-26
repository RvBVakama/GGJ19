using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignCursor : MonoBehaviour
{
    public Texture2D cursorTex = null;

    // Use this for initialization
    void Awake()
    {
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.Auto);
        Debug.Log("hit enter");
    }
//    void OnMouseExit()
//    {
//        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
//        Debug.Log("hit exit");
//    }
}
