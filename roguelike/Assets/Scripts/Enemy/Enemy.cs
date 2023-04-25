using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AIDestinationSetter>().target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // If a bullet hits an enemy, destroy the enemy object and the bullet itself.
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Helth>().TakeDamage(1);

        }
    }


}
