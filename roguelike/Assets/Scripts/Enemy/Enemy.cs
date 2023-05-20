using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        var gameObjectP = GameObject.Find("Player");
        if(gameObjectP == null ) return;
        _player = gameObjectP.transform;
        
        var aiDest = GetComponent<AIDestinationSetter>();
        if (aiDest == null) return;
        aiDest.target = _player;
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon == null) return;
        if(_player == null) return;
        if(_frameCounter == framesBetwenShoot)
        {
            weapon.firePoint.up = _player.position - transform.position;
            weapon.Shoot();
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
