using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private bool playerInside = false;
    
    public AudioSource audioSource;
    public AudioClip musicClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

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
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            ToggleMusic();
        }
    }
    
    void ToggleMusic()
    {
        if (musicClip != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.clip = musicClip;
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("Aucun AudioClip assigné. Veuillez assigner un AudioClip dans l'inspecteur.");
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
