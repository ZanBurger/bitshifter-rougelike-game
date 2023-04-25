using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helth : MonoBehaviour
{
    public int livePoints = 1;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
