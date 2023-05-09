using System.Collections;
using UnityEngine;

public class HitBomb : MonoBehaviour
{
    private Bomb bomb;

    private void Start()
    {
        bomb = GetComponent<Bomb>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Bomb triggered by: " + other.gameObject.name);
            if (bomb != null)
            {
                StartCoroutine(bomb.ExplodeWithDelay(0.2f));
            }
        }
        
    }
}