using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public GameObject player;
    public Transform respawnPoint;
    public Image[] livesUI;
    public int scoreOnDeath;

    [HideInInspector]
    public bool isDead;

    void Start()
    {
        // Disable all the livesUI images
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = false;
        }

        // Enable only the number of lives that the player currently has
        for (int i = 0; i < lives; i++)
        {
            livesUI[i].enabled = true;
        }
    }
}
