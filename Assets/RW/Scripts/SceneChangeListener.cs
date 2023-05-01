using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeListener : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {   
        if (scene.name == "Game")
        {
            PlayerController playerController = FindObjectOfType<PlayerController>(true);
            if (playerController != null)
            {
                playerController.UpdateKeyBindings();
            }
        }
    }
}