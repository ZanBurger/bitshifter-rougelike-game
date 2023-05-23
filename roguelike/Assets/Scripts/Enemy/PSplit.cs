using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pathfinding.SimpleSmoothModifier;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PSplit : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bombPrefab;
    public int timeToSplit = 60;
    public int booletSpeet = 5;
    public int shootingType = 0;

    GameObject bulletToShoot;
    void Start()
    {
        Destroy(gameObject, 2f);
        if (Random.value > 0.5)
        {
            bulletToShoot = bulletPrefab;
        }
        else
        {
            bulletToShoot = bombPrefab;
        }
        
        
    }

    int _frameCounter = 0;
    void FixedUpdate()
    {
        if (_frameCounter == timeToSplit)
        {
            Split();
        }
        _frameCounter++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Helth>().TakeDamage(1);
            Split();
        }
        // If a bullet hits an obstacle (walls..), just destroy the bullet.
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Split();
        }
    }

    void Split()
    {
        switch (shootingType)
        {
            case 0:
                ShootAll();
                break;
            case 1:
                ShootTree();
                break;
            default:
                break;
        }
        Destroy(gameObject);
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
        Vector2 playerDirection = GetComponent<Rigidbody2D>().velocity;
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
