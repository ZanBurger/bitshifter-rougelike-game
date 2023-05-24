using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownBomb : MonoBehaviour
{
    public GameObject fillBomb;
    private float timer;
    private bool shouldDisableFill;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fillBomb.SetActive(true);
            timer = Time.time + 4.15f; // Set the timer to the current time plus 5 seconds
            shouldDisableFill = true;
        }

        if (shouldDisableFill && Time.time >= timer)
        {
            fillBomb.SetActive(false);
            shouldDisableFill = false;
        }
    }
}
