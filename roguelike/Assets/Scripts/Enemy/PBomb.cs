using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBomb : MonoBehaviour
{
    public GameObject Player;
    public int damage = 5;
    public float distacneToDealDamage = 1f;
    public int timeToExplode = 60;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    int _frameCounter = 0;
    void FixedUpdate()
    {
        if (Player == null) return;

        if (_frameCounter == timeToExplode)
        {
            Explode();
        }
        _frameCounter++;
    }

    void Explode()
    {
        if(Player == null) return;
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        //if distance is less than 0.5f, destroy the bullet
        if (distance < distacneToDealDamage)
        {
            Destroy(gameObject);
            Player.GetComponent<Helth>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Explode();
        }
        // If a bullet hits an obstacle (walls..), just destroy the bullet.
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Explode();
        }
    }
}
