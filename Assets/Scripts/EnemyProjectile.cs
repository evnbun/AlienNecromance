using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectlie;


    
    // Start is called before the first frame update
    void Start()
    {         
       timeBetweenShots = startTimeBetweenShots; 
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy shooting at Player
        if(timeBetweenShots <= 0)
        {
            Instantiate(projectlie, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        } 
        else 
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
