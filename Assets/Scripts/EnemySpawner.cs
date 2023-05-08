using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    [SerializeField] private PlayerLives playerLives;

    private void Start()
    {
        //Enemy Spawn
        playerLives = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLives>();
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        //How long the enemy spawns
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn && playerLives.lives > 0)
        {
            //Enemy spawn rate
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}

