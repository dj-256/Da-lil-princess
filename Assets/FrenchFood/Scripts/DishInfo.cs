using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishInfo : MonoBehaviour
{
    public string dishInformation = "Information about the dish";
    private bool playerInside = false;
    private bool showInformation = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            showInformation = false;
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            showInformation = !showInformation;
        }
    }

    private void DrawBlackBackground()
    {
        GUI.backgroundColor = Color.black;
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
    }

    private void OnGUI()
    {
        int fontSize = 24;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = fontSize;
        style.alignment = TextAnchor.UpperCenter;

        float labelWidth = 600;
        float labelHeight = fontSize + 10;
        float xPos = (Screen.width - labelWidth) / 2;
        float yPos = Screen.height - 70;

        if (playerInside && !showInformation)
        {
            GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), "Press E to open information about this dish", style);
        }

        if (showInformation)
        {
            DrawBlackBackground();
            
            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.MiddleCenter;
            yPos = (Screen.height - labelHeight) / 2;
            GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), dishInformation, style);
        }
    }
}
