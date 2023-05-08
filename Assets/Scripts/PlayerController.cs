using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Rigidbody2D rb;
    public Camera cam;
    public static event Action OnPlayerDeath;

    public PlayerLives playerLives; // Reference to PlayerLives script
    public ScoreManager scoreManager; // Reference to ScoreManager script
    public Leaderboard leaderboard; //Reference to Leaderboard

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        playerLives = GetComponent<PlayerLives>(); // Get PlayerLives script component
        scoreManager = ScoreManager.instance; // Get ScoreManager singleton instance
    }

    //Player movement & shooting
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //Player shoot function
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    //Player Direction
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    //Player collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject, 0.5f);
            playerLives.lives -= 1;

            for (int i = 0; i < playerLives.livesUI.Length; i++)
            {
                if (i < playerLives.lives)
                {
                    playerLives.livesUI[i].enabled = true;
                }
                else
                {
                    playerLives.livesUI[i].enabled = false;
                }
            }

            transform.position = playerLives.respawnPoint.position;

            if (playerLives.lives <= 0 && !playerLives.isDead)
            {
                playerLives.isDead = true;
                StartCoroutine(DieRoutine());
            }
        }
    }

    //Player Death
    IEnumerator DieRoutine()
    {
        // Add score to the score manager
        scoreManager.AddScore(playerLives.scoreOnDeath);

        // Wait for 1 second before showing game over screen
        yield return new WaitForSeconds(1f);

        // Submit score to the leaderboard
        yield return leaderboard.SubmitScoreRoutine(scoreManager.score);

        // Disable player game object
        gameObject.SetActive(false);

        // Show game over screen
        Debug.Log("Game Over");

        OnPlayerDeath?.Invoke();
        FindObjectOfType<GameOver>().EnableGameOverMenu();
        
    }
}


