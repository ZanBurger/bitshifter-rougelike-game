using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
//using static Pathfinding.Util.GridLookup<T>;
using static UnityEditor.PlayerSettings;


public class Enemy : MonoBehaviour
{
   
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bombPrefab;
    int framesBetwenShoot;
    GameObject _player;
    int _frameCounter = 0;
    GameObject bulletToShoot;
    int booletSpeet = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        var gameObjectP = GameObject.Find("Player");
        if (gameObjectP == null) return;
        _player = gameObjectP;

        GetComponent<Helth>().livePoints = Random.Range(1, 3);
        booletSpeet = Random.Range(9, 10);

        var BombSettings = bombPrefab.GetComponent<PlayerHitBomb>();
        BombSettings.Player = _player;

        if (Random.value > 0.5)
        {
            framesBetwenShoot = 60;
            bulletToShoot = bulletPrefab;
        }
        else
        {
            framesBetwenShoot = 120;
            bulletToShoot = bombPrefab;
        }

        var aiDest = GetComponent<AIDestinationSetter>();
        if (aiDest == null) return;
        aiDest.target = _player.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_player == null) return;
        if(_frameCounter == framesBetwenShoot)
        {
            ShootTree();
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
    
    void ShootOne()
    {
        Vector2 vector2 = transform.position;
        GameObject bullet = Instantiate(bulletToShoot, vector2, Quaternion.identity);
       
        // Add velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        //vector from enemy to player
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();
        rb.AddForce(direction * booletSpeet, ForceMode2D.Impulse);
    }

    static Vector2[] directions = new Vector2[8] 
    {
        new Vector2(1, 0), 
        new Vector2(0.7f, 0.7f), 
        new Vector2(0, 1), 
        new Vector2(-0.7f, 0.7f), 
        new Vector2(-1, 0), 
        new Vector2(-0.7f, -0.7f), 
        new Vector2(0, -1), 
        new Vector2(0.7f, -0.7f) 
    };

    void ShootAll()
    {
        foreach (Vector2 direction in directions)
        {
            GameObject bullet = Instantiate(bulletToShoot, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * booletSpeet, ForceMode2D.Impulse);
        }
    }

    static float[] angles = new float[3] { 10, 0, -10 };
    void ShootTree()
    {
        Vector2 vector2 = transform.position;
        Vector2 playerDirection = _player.transform.position - transform.position;
        playerDirection.Normalize();

        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(bulletToShoot, vector2, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            // Create a quaternion representing the rotation
            Quaternion rotation = Quaternion.Euler(0f, 0f, angles[i]);

            // Rotate the vector using the quaternion
            Vector2 direction = rotation * playerDirection;

            rb.AddForce(direction * booletSpeet, ForceMode2D.Impulse);
        } 
    }
}
