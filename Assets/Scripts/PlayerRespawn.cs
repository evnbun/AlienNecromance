using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject playerPrefab;      // Prefab for the player game object
    public GameObject respawnEffect;     // Particle effect to play when the player respawns

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Player has entered a death zone - respawn at the start of the level
            Respawn();
        }
    }

    void Respawn()
    {
        // Spawn the player prefab at the start position and rotation
        GameObject newPlayer = Instantiate(playerPrefab, transform.position, transform.rotation);

        // Spawn the respawn effect at the player's position
        Instantiate(respawnEffect, transform.position, Quaternion.identity);

        // Destroy the current player game object
        Destroy(gameObject);
    }
}
