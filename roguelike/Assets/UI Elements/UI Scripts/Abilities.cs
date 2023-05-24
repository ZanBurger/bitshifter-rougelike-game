using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public GameObject movementUI;
    public GameObject rateUI;

    // Abilites UI elements
    public GameObject teleportUI;
    public GameObject multiUI;
    public GameObject bombUI;
    public GameObject sprintUI;

    

    // Start is called before the first frame update
    void Start()
    {
        PickUp.isPickedMovement = false;
        PickUp.isPickedRate = false;

        if (PlayerController.unlockedTeleport == true)
        {
            if(teleportUI != null)
            {
                teleportUI.SetActive(true);
            }
        }

        if (PlayerController.unlockedMultishot == true)
        {
            if (multiUI != null)
            { multiUI.SetActive(true); }
        }
        
        if (PlayerController.unlockedBomb == true)
        { 
            if (bombUI != null)
            { 
                bombUI.SetActive(true); 
            }
        }

        if (PlayerController.unlockedRun == true)
        {
            if(sprintUI != null)
            { sprintUI.SetActive(true); }
        }
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
