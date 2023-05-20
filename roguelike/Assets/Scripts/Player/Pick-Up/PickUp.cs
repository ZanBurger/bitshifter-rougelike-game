using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){

            Player.IncreasedMovement effect = other.gameObject.AddComponent<Player.IncreasedMovement>();

            effect.playerController = other.GetComponent<PlayerController>();

            Destroy(gameObject);
        }
    }
}
