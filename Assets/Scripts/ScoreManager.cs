using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton instance of the ScoreManager

    public int score = 0; // Current score
    public Text scoreText; // UI text element to display the score

    void Awake()
    {
        // Ensure there is only one instance of the ScoreManager in the scene
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}

