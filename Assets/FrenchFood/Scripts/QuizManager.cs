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
            DrawBackgroundOverlay();
            DisplayQuizTitle();
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

	private void DisplayQuizTitle()
    {
        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        titleStyle.fontSize = 36;
        titleStyle.alignment = TextAnchor.UpperCenter;
        GUILayout.BeginArea(new Rect(0, 60, Screen.width, 100));
        GUILayout.Label("QUIZ", titleStyle);
        GUILayout.EndArea();
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

            GUIStyle questionStyle = new GUIStyle(GUI.skin.label);
            questionStyle.fontSize = 24;
            questionStyle.alignment = TextAnchor.MiddleCenter;

            GUIStyle answerStyle = new GUIStyle(GUI.skin.label);
            answerStyle.fontSize = 20;
            answerStyle.alignment = TextAnchor.MiddleLeft;

            GUILayout.BeginArea(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200));
            GUILayout.Label(currentQuestion.questionText, questionStyle);

            for (int i = 0; i < currentQuestion.answers.Length; i++)
            {
                GUILayout.Label((char)('A' + i) + ". " + currentQuestion.answers[i], answerStyle);
            }
            GUILayout.EndArea();
        }
        else
        {
            quizFinished = true;
        }
    }

	private void DrawBackgroundOverlay()
    {
        GUIStyle overlayStyle = new GUIStyle();
        overlayStyle.normal.background = Texture2D.whiteTexture;
        Color originalColor = GUI.color;
        GUI.color = new Color(0, 0, 0, 0.5f);
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none, overlayStyle);
        GUI.color = originalColor;
    }

    private void DisplayQuizResults()
	{
    	GUIStyle resultsStyle = new GUIStyle(GUI.skin.label);
    	resultsStyle.fontSize = 24;
    	resultsStyle.alignment = TextAnchor.MiddleCenter;

    	Rect resultsRect = new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 300, 200);
    	GUI.Label(resultsRect, "Quiz Finished!\nYour score: " + score + "/" + questions.Count, resultsStyle);
	}
}
