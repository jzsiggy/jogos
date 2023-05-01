using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    private Button pauseButton;
    public PauseManager pauseManager;

    private void Start()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(PauseGame);
    }

    private void PauseGame()
    {
        pauseManager.Pause();
    }
}