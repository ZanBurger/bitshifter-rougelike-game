using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEditor.Experimental.GraphView.GraphView;

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

    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        var gameObjectP = GameObject.Find("Player");
        if (gameObjectP == null) return;
        _player = gameObjectP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if( Time.fixedTime - summon > summonTime){

            if(_player == null) return;
            var distance = Vector2.Distance(transform.position, _player.transform.position);
            if (distance > 25) return;

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
