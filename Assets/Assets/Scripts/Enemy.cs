using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy initial health amount
    public int health = 100;
    //Enemy initial score value
    public int scoreValue = 100;

    public GameObject deathEffect;

    //Array of dropped items 
    public GameObject[] itemDrops;

    //Enemy Damage
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die(); // Enemy dies when health is <= 0
        }
    }

    void Die()
    {
        ScoreManager.instance.AddScore(scoreValue); //Score added
        Destroy(gameObject); //Enemy is destroyed
        ItemDrop(); //Enemy drops item
    }
    
    //Enemy drops
    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
    
}
