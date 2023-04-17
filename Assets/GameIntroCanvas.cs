using UnityEngine;
using UnityEngine.UI;

public class GameIntroCanvas : MonoBehaviour
{
    private bool displayText = true;
    
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            displayText = !displayText;
            panel.SetActive(true);
        }
    }
}