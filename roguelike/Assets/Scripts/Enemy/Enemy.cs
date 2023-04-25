using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Weapon weapon;
    public int framesBetwenShoot;
    Transform _player;
    int _frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        var aiDest = GetComponent<AIDestinationSetter>();
        if (aiDest == null) return;
        aiDest.target = _player;
    }

    // Update is called once per frame
    void Update()
    {
        if(_frameCounter == framesBetwenShoot)
        {
            if (weapon != null)
            {
                weapon.Shoot();
            }
            _frameCounter = 0;
        }
        _frameCounter++;
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
