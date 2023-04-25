using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTiles : MonoBehaviour
{
    [SerializeField] private GameObject tilemap;
    public float timeToToggle = 5;
    public float currentTime = 0;

    public new bool enabled = true;
    
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    void Update() {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToToggle){
            currentTime = 0;
            ToggleTile();
        }
    }

    void ToggleTile(){
        enabled = !enabled;
        tilemap.gameObject.SetActive(enabled);
    }
}
