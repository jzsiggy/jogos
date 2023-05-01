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

    private void Update()
    {
        if (sceneStarted && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)))
        {
            sceneStarted = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (eventSystem.currentSelectedGameObject != null)
            {
                Button selectedButton = eventSystem.currentSelectedGameObject.GetComponent<Button>();
                if (selectedButton != null)
                {
                    selectedButton.onClick.Invoke();
                }
            }
        }
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