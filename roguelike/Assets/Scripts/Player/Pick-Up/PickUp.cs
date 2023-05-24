using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static bool isPickedMovement = false;
    public static bool isPickedRate = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        // Generate a random number between 0 and 1 to determine the ability type
        var abilityType = Random.Range(0, 2);
        switch (abilityType)
        {
            case 0:
                if (!other.gameObject.GetComponent<Player.IncreasedMovement>())
                {
                    Player.IncreasedMovement increasedMovementEffect = other.gameObject.AddComponent<Player.IncreasedMovement>();
                    increasedMovementEffect.playerController = other.GetComponent<PlayerController>();
                    isPickedMovement = true;
                }
                break;
            case 1:
                if (!other.gameObject.GetComponent<Player.IncreasedFirerate>())
                {
                    Player.IncreasedFirerate increasedFirerateEffect = other.gameObject.AddComponent<Player.IncreasedFirerate>();
                    Weapon weapon = other.gameObject.GetComponentInChildren<Weapon>();
                    increasedFirerateEffect.Initialize(weapon);
                    isPickedRate = true;
                }
                break;
                    
        }

        Destroy(gameObject);
    }
}