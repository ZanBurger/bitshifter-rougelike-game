using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    private string fireButton = "Fire1";
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    private float nextFireTime = 0f;
    private float currentFirerate;
    private IncreasedFirerate increasedFirerate;
    bool equippedMultiShot = false;

    private void EquipIncreasedFirerate()
    {
        increasedFirerate = GetComponent<IncreasedFirerate>();
        if (increasedFirerate != null)
        {
            increasedFirerate.enabled = true;
        }
    }
    void Start()
    {
        if (firePoint == null)  
        {
            firePoint = transform;
        }
        currentFirerate = 0.25f; // Higher number = slower firerate
       //EquipIncreasedFirerate();
    }

    void Update()
    {
        if (Input.GetButton(fireButton) && Time.time >= nextFireTime)
        {
            InstantiateBullet();
            nextFireTime = Time.time + currentFirerate;
        }
    }

    private void InstantiateBullet()
    {
        if (equippedMultiShot)
        {
            // Create three bullets from the Bullet Prefab
            GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Add velocity to the middle bullet
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            // Add velocity to the right bullet
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(Quaternion.Euler(0, 0, -25) * firePoint.up * bulletForce, ForceMode2D.Impulse);

            // Add velocity to the left bullet
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(Quaternion.Euler(0, 0, 25) * firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else
        {
            // Create a single bullet from the Bullet Prefab
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Add velocity to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }


    public void SetCurrentFirerate(float newFirerate)
    {
        currentFirerate = newFirerate;
    }
}