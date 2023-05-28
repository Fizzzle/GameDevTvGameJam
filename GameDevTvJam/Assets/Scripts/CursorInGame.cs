using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInGame : MonoBehaviour
{
    [Header("Cursor Settings")]
    public Texture2D cursorTexture;
    public Texture2D cursorTextureDark;
    private Vector2 cursorSize = new Vector2(22, 22);
    private Vector2 cursorOffset = new Vector2(4, 18);
    private SwitchSide SwitchSide;
    
    
    // Start is called before the first frame update

    private void Awake()
    {
        cursorTexture = Resources.Load("Prefabs/Cursor/CursorLight") as Texture2D;
        cursorTextureDark = Resources.Load("Prefabs/Cursor/CursorDark") as Texture2D;
    }

    void Start()
    {
        SwitchSide = GameObject.FindObjectOfType<SwitchSide>();
        UnityEngine.Cursor.visible = false;
    }

    void OnGUI()
    {
        if (SwitchSide.Light)
        {
            CursorVisible(cursorTexture);
        }
        else
        {
            CursorVisible(cursorTextureDark);
        }
    }

    void CursorVisible(Texture2D cursorObject)
    {
        Vector2 mousePosition = Event.current.mousePosition;
        Rect cursorRect = new Rect(mousePosition.x - cursorOffset.x, mousePosition.y - cursorOffset.y, cursorSize.x, cursorSize.y);
        GUI.DrawTexture(cursorRect, cursorObject);
    }
}
