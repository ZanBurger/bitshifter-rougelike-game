using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownTele : MonoBehaviour
{
    public GameObject fillTele;
    private float timer;
    private bool shouldDisableFill;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            fillTele.SetActive(true);
            timer = Time.time + 4.9f; // Set the timer to the current time plus 5 seconds
            shouldDisableFill = true;
        }

        if (shouldDisableFill && Time.time >= timer)
        {
            fillTele.SetActive(false);
            shouldDisableFill = false;
        }
    }
}
