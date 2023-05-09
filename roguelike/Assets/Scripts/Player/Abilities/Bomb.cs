using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombRadius = 5f;
    public float bombForce = 10f;
    public int bombDamage = 1;

    public void Explode()
    {
        Debug.Log("Explode");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, bombRadius); // Find all colliders in the bomb radius.

        foreach (Collider2D collider in colliders)
        {
            if (!collider.gameObject.CompareTag("Player"))
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>(); // Get the rigidbody of each collider.
                if (rb != null)
                {
                    Vector2 explosionDirection = (rb.transform.position - transform.position).normalized;  // Get the direction of rigidbody from the bomb, normalize to disregard distance and focus on direction.
                    float distance = Vector2.Distance(transform.position, rb.transform.position); // Calculate the distance between the bomb and the collider.
                    float explosionPower = 1 - distance / bombRadius; // 1 -> max damage, so we subtract how far the object is from the bomb explosion radius.
                    explosionPower = Mathf.Clamp(explosionPower, 0f, 1f); // Adjust damage according to distance from explosion but not less than 0 and not more than 1.
                    rb.AddForce(explosionDirection * bombForce * explosionPower, ForceMode2D.Impulse); // Add the force to the rigidbody.
                }

                if (collider.gameObject.CompareTag("Enemy"))
                {
                    collider.gameObject.GetComponent<Helth>().TakeDamage(bombDamage);
                    Debug.Log("Damage dealt to enemy: " + collider.gameObject.name);
                }
            }
        }
        Destroy(gameObject);
    }

    public IEnumerator ExplodeWithDelay(float delay)
    {
        Debug.Log("ExplodeWithDelay");
        yield return new WaitForSeconds(delay);
        Explode();
    }
}