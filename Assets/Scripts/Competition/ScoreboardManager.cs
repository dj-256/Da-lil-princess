using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "You collected "+LapManager.score.ToString()+" coins";
        timeText.text = "Your time was "+LapManager.finalTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
