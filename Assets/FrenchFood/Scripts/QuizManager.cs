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
    private bool quizActive = false;

	public void ExitQuiz()
	{
		currentQuestionIndex = 0;
		score = 0;
		quizFinished = false;
		quizActive = false;
	}

	public void BeginQuiz()
	{
		quizActive = true;
		quizFinished = false;
	}

    public void ToggleQuiz()
    {
        quizActive = !quizActive;
    }

    private void Update()
    {
        if (quizActive && !quizFinished)
        {
            CheckForKeyPress();
        }
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

    private void CheckForKeyPress()
    {
        int selectedIndex = -1;

        if (Input.GetKeyDown(KeyCode.A)) selectedIndex = 0;
        else if (Input.GetKeyDown(KeyCode.B)) selectedIndex = 1;
        else if (Input.GetKeyDown(KeyCode.C)) selectedIndex = 2;
        else if (Input.GetKeyDown(KeyCode.D)) selectedIndex = 3;

        if (selectedIndex >= 0)
        {
            CheckAnswer(selectedIndex);
        }
    }

    private void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            score++;
        }
        currentQuestionIndex++;

        if (currentQuestionIndex >= questions.Count)
        {
            quizFinished = true;
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
                GUILayout.Label((char)('A' + i) + ". " + currentQuestion.answers[i]);
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
