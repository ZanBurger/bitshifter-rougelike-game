using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random; // To not confuse with System.Random

public class BulletHitEnemy : MonoBehaviour
{
    public GameObject pickUpPrefab;
    private void Start(){
        // Destroy after 2s if we don't hit anything.
        Destroy(gameObject, 2f);
    }
   void OnCollisionEnter2D(Collision2D other){
        float dropChance = Random.value; // Generate random float between 0 and 1
       // If a bullet hits an enemy, destroy the enemy object and the bullet itself.
        if(other.gameObject.CompareTag("Enemy")){
            // Enemy has a 20% chance of dropping an item
            if (dropChance <= 0.2f)
            {
                Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
            }         
            Destroy(gameObject);
            other.gameObject.GetComponent<Helth>().TakeDamage(1);
        }
        // If a bullet hits an obstacle (walls..), just destroy the bullet.
        else if (other.gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
        
    }
}
