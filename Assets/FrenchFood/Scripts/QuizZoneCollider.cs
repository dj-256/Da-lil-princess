using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizZoneCollider : MonoBehaviour
{
    private bool playerInside = false;
    public QuizManager quizManager; // Ajoutez une référence au script QuizManager

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
			quizManager.ExitQuiz();
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            quizManager.BeginQuiz();
        }
    }
}
