using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public GameObject movementUI;
    public GameObject rateUI;

    // Start is called before the first frame update
    void Start()
    {
        PickUp.isPickedMovement = false;
        PickUp.isPickedRate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PickUp.isPickedMovement == false)
        {
            if (movementUI != null)
            {
                movementUI.SetActive(false);
            }
        }
        else
        {
            if (movementUI != null)
            {
                movementUI.SetActive(true);
            }
        }

        if (PickUp.isPickedRate == false) 
        { 
            if(rateUI != null)
            {
                rateUI.SetActive(false);
            }    
        }
        else
        { 
            if (rateUI != null)
            {
                rateUI.SetActive(true);
            } 
        }

    }
}
