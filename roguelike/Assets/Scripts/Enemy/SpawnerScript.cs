using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public float summonTime = 5;
    public float summonRadius = 5;
    float summon = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Time.fixedTime - summon > summonTime){
            Vector2 pos = Random.insideUnitCircle * summonRadius;
            pos += new Vector2(transform.position.x, transform.position.y);
            Instantiate(enemy, pos, Quaternion.identity);
            summon = Time.fixedTime;
        }
    }
}