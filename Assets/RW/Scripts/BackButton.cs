// Purpose: This script is used to go back to the main menu.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    private void Start(){}

    private void Update(){}

    public void RetryGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
}
