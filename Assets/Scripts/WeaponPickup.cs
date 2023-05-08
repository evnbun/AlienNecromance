using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab;
    public float pickupRange = 1f;

    private Transform player;
    private bool isPickedUp = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isPickedUp && Vector3.Distance(transform.position, player.position) < pickupRange)
        {
            PickUpWeapon();
        }
    }

    private void PickUpWeapon()
    {
        isPickedUp = true;
        Instantiate(weaponPrefab, player.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}

