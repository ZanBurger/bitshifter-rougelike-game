using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public float summonTime = 5f;
    float summon = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Time.fixedTime - summon > summonTime){
            Vector2 pos = Random.insideUnitCircle * 5;
            Instantiate(enemy, pos, Quaternion.identity);
            summon = Time.fixedTime;
        }
    }
}
