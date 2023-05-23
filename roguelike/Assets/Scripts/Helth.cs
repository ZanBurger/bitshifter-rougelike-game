using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Helth : MonoBehaviour
{
    public int livePoints = 1;
    public int maxHealth = 8;

    public Healthbar healthbar;

    void Start()
    {
        if (healthbar == null) return;
        healthbar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        livePoints -= damage;
        if (livePoints <= 0)
        {
            Destroy(gameObject);
        }
        if(healthbar != null)
        {
            healthbar.setHealth(livePoints);
        }
    }
}
