using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Helth : MonoBehaviour
{
    private GameObject player;
    public int livePoints = 1;
    public int maxHealth = 8;
    public Healthbar healthbar;

    void Start()
    {
        if (healthbar == null) return;
        healthbar.SetMaxHealth(maxHealth);
       
    }

    public void TakeDamage(int damage)
    {
        livePoints -= damage;
        if (livePoints <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                PlayerController.deathAmount++;
                Debug.Log("Death amount: " + PlayerController.deathAmount);
                CheckAbilityStatus(PlayerController.deathAmount);

            }
            Destroy(gameObject);
        }
        if(healthbar != null)
        {
            healthbar.setHealth(livePoints);
        }
    }

    private void CheckAbilityStatus(int deathAmount)
    {
        if (deathAmount >= 2 && !PlayerController.unlockedTeleport)
        {
            PlayerController.unlockedTeleport = true;
            Debug.Log("Teleport unlocked");
        }
        if (deathAmount >= 4 && !PlayerController.unlockedMultishot)
        {
            PlayerController.unlockedMultishot = true;
            Debug.Log("Multishot unlocked");
        }
        if (deathAmount >= 6)
        {
            PlayerController.unlockedBomb = true;
            Debug.Log("Bomb unlocked");
        }
        if (deathAmount >= 7)
        {
            PlayerController.unlockedRun = true;
            Debug.Log("Run unlocked");
        }
    }
}
