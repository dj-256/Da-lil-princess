using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScript : MonoBehaviour
{
    private bool displayText = false;

    public string introText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //displayText = !displayText;
        }
    }
    
    void OnGUI()
    {
        if (displayText)
        {
            GUIStyle backgroundStyle = new GUIStyle(GUI.skin.box);
            backgroundStyle.normal.background = Texture2D.blackTexture;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none, backgroundStyle);

            GUIStyle textStyle = new GUIStyle(GUI.skin.box);
            textStyle.alignment = TextAnchor.MiddleCenter;
            textStyle.fontSize = 20;
            textStyle.wordWrap = true;
            textStyle.normal.textColor = Color.white;

            GUI.Box(new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f), introText, textStyle);
        }
    }
}
