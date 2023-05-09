using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    float summonTime = 5;
    public float minSummonTime = 1;
    public float maxSummonTime = 5;
    public float summonRadius = 5;
    public int minSummonAmount = 5;
    public int maxSummonAmount = 10;
    int summonAmount = 1;
    float summon = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Time.fixedTime - summon > summonTime){
            for (int i = 0; i < summonAmount; i++)
            {
                Vector2 pos = Random.insideUnitCircle * summonRadius;
                pos += new Vector2(transform.position.x, transform.position.y);
                Instantiate(enemy, pos, Quaternion.identity);
            }
            summonAmount = Mathf.RoundToInt(Random.Range(minSummonAmount, maxSummonAmount));
            summonTime = Random.Range(summonTime, summonAmount);

            summon = Time.fixedTime;
        }
    }
}
