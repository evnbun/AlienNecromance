using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ammoType;

    public float shotSpeed;
    public float shotCounter, fireRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shotCounter-= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
            }
        }
        else 
        {
            shotCounter = 0;
        }
    }

    void Shoot()
    {
        GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>(); 
        rb.AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
        Destroy(shot.gameObject, 1f);
    }
}
