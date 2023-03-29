using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionDisplay : MonoBehaviour
{
    private bool playerInside = false;

    public string regionName = "region name";

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

    private void OnGUI()
    {
        if (playerInside)
        {
            int fontSize = 40;
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = fontSize;
            style.alignment = TextAnchor.UpperCenter;

            float labelWidth = 600;
            float labelHeight = fontSize + 10;
            float xPos = (Screen.width - labelWidth) / 2;
            float yPos = 10;
            float borderSize = 2; // Définissez la taille de la bordure ici

            // Dessiner la bordure noire
            style.normal.textColor = Color.black;
            for (int i = 0; i < 8; i++)
            {
                float xOffset = (i % 3 - 1) * borderSize;
                float yOffset = (i / 3 - 1) * borderSize;
                GUI.Label(new Rect(xPos + xOffset, yPos + yOffset, labelWidth, labelHeight), regionName, style);
            }

            // Dessiner le texte au-dessus de la bordure
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(xPos, yPos, labelWidth, labelHeight), regionName, style);
        }
    }
}
