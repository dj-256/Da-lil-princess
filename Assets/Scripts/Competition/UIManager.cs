using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI lapText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winnerText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLapText(string message)
    {
        lapText.text = message;
    }

    public void UpdateScoreText(string message)
    {
        scoreText.text = message;
    }

    public void UpdateWinnerText(string message)
    {
        winnerText.text = message;
    }
}
