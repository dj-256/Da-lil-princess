using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(4);
    }
}
