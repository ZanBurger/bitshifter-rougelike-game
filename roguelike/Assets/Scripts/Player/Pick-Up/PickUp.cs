using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Generate a random number between 0 and 1 to determine the ability type
            // int abilityType = Random.Range(0, 2);
            int abilityType = 0;
            switch (abilityType)
            {
                case 0:
                    if (!other.gameObject.GetComponent<Player.IncreasedMovement>())
                    {
                        Player.IncreasedMovement increasedMovementEffect = other.gameObject.AddComponent<Player.IncreasedMovement>();
                        increasedMovementEffect.playerController = other.GetComponent<PlayerController>();
                    }
                    break;
            }

            Destroy(gameObject);
        }
    }
}