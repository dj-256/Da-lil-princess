using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public struct Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIndex;
    }

    public List<Question> questions;
    private int currentQuestionIndex = 0;
    private int score = 0;
    private bool quizFinished = false;
	public bool quizActive = false;

	public void ToggleQuiz()
    {
        quizActive = !quizActive;
    }

    private void OnGUI()
    {
        if (quizActive)
        {
            if (!quizFinished)
            {
                DisplayCurrentQuestion();
            }
            else
            {
                DisplayQuizResults();
            }
        }
    }

    private void DisplayCurrentQuestion()
{
    if (currentQuestionIndex < questions.Count)
    {
        Question currentQuestion = questions[currentQuestionIndex];

        GUILayout.BeginArea(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200));
        GUILayout.Label(currentQuestion.questionText);

        for (int i = 0; i < currentQuestion.answers.Length; i++)
        {
            if (GUILayout.Button(currentQuestion.answers[i]))
            {
                if (i == currentQuestion.correctAnswerIndex)
                {
                    score++;
                }

                currentQuestionIndex++;
            }
        }
        GUILayout.EndArea();
    }
    else
    {
        quizFinished = true;
    }
}

    private void DisplayQuizResults()
{
    GUILayout.BeginArea(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200));
    GUILayout.Label("Quiz Finished!");
    GUILayout.Label("Your score: " + score + "/" + questions.Count);
    GUILayout.EndArea();
}
}
