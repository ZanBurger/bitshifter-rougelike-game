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
        currentFirerate = 0.1f;
       EquipIncreasedFirerate();
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
        // Create the Bullet from the Bullet Prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public void SetCurrentFirerate(float newFirerate)
    {
        currentFirerate = newFirerate;
    }
}