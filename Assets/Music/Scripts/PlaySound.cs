using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private bool playerInside = false;

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
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("player is inside");
        }
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

        if (playerInside)
        {
            GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), "Press E to play a sound from this instrument", style);
        }
    }
}
