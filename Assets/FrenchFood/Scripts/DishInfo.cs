using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishInfo : MonoBehaviour
{
    public string dishTitle = "Dish Title";
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
        int fontSize = 22;
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

            GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
            titleStyle.fontSize = fontSize * 2;
            titleStyle.alignment = TextAnchor.MiddleCenter;
            titleStyle.normal.textColor = Color.white;

            yPos = 50; // Move the title closer to the top
            GUI.Label(new Rect(xPos, yPos, labelWidth, fontSize * 2 + 10), dishTitle, titleStyle);

            style.normal.textColor = Color.white;
            style.alignment = TextAnchor.UpperLeft;
            style.wordWrap = true;

            yPos += fontSize * 2 + 30; // Adjust the yPos for the description box

            float boxWidth = labelWidth;
            float boxHeight = Screen.height - yPos - 50;
            Rect descriptionRect = new Rect(xPos, yPos, boxWidth, boxHeight);

            GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
            boxStyle.alignment = TextAnchor.UpperLeft;
            boxStyle.fontSize = fontSize;
            boxStyle.normal.textColor = Color.white;
            boxStyle.wordWrap = true;

            GUI.Box(descriptionRect, dishInformation, boxStyle);
        }
    }
}
