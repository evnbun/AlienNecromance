using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Bullet speed
    public float speed = 20f;
    
    //Bullet registering that it hit an enemy
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(25); //Bullet damage
        }
        Destroy(gameObject);

    }
}

