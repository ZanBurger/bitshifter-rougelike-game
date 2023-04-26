using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;

    void Start()
    {
        if(firePoint == null)
        {
            firePoint = transform;
        }
    }

    public void Shoot(){
        // Create the Bullet from the Bullet Prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Add velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
