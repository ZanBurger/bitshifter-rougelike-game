using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{

    GameObject player;
    public float speed = 5f;

    float boarn;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 0)
        {
            player = players[0];
        }

        boarn = Time.fixedTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime - boarn > 10)
        {
            Destroy(gameObject);
        }
        if (player == null) return;
        float distance = Vector2.Distance(player.transform.position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(distance < 0.5)
        {
            Destroy(player);
        }

        
    }
}