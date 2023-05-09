using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public PlayerController playerController;
    public float  teleportDistance;
    public bool onCooldown;
    public int cooldownDuration = 5;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        teleportDistance = 0.5f;
        onCooldown = false;
    }

    public void TeleportPlayer(){
        StartCoroutine(TeleportCoroutine());
    }
    
    IEnumerator TeleportCoroutine(){
        
        var player = playerController.transform;
        Vector3 forward = player.up;
        Vector3 newPosition = player.position + forward * teleportDistance;
        var spriteRenderer = player.GetComponent<SpriteRenderer>();
        if(spriteRenderer != null){
            spriteRenderer.enabled = false; 
        }
        player.position = newPosition;
        yield return new WaitForSeconds(0.3f);
        if(spriteRenderer != null){
            spriteRenderer.enabled = true;
        }
        onCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        onCooldown = false;
    }
    
    
}
