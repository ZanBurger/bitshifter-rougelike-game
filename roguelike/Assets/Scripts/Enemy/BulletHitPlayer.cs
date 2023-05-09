using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitPlayer : MonoBehaviour
{
    private void Start()
    {
        //Destroy after 2s if we don't hit anything.
        Destroy(gameObject, 2f);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        // If a bullet hits an enemy, destroy the enemy object and the bullet itself.

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Helth>().TakeDamage(1);
        }
        // If a bullet hits an obstacle (walls..), just destroy the bullet.
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
