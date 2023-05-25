using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour{
    public Button startButton;
    public EventSystem eventSystem;

    private bool sceneStarted = true;

    private void Start()
    {
        eventSystem.SetSelectedGameObject(startButton.gameObject);
    }

    public void StartGame()
    {
        eventSystem.enabled = false;
        if (ScoreManager.highScore == 0)
        {
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }  

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}