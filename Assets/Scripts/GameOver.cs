using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;

    //Game over screen enabled
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += EnableGameOverMenu;
    }

    //Game Over screen disabled
    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= EnableGameOverMenu;
    }

    //Displays GameOver Screen
    public void EnableGameOverMenu()
    {
        Debug.Log("Enabling Game Over Menu...");
        gameOverMenu.SetActive(true);
    }

    //Restarts game
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    //Go to menu
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
