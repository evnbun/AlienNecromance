using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public int health = 100;

  public GameObject death;
  public Transform target;

  public float speed = 3f;

  public float rotateSpeed = 0.0025f;
  
  public Rigidbody2D rb;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }
  
  public void TakeDamage (int damage)
  {
    health -= damage;

    if (health <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    Instantiate(death, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }

}