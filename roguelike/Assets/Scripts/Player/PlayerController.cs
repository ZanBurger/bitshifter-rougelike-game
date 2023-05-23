using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 _moveDirection;
    private Teleport teleport;
    private IncreasedMovement increasedMovement;
    public static int deathAmount = 0;
    public static bool unlockedTeleport = false;
    public static bool unlockedBomb = false;
    private Vector2 _lookDirection;

    public static bool  unlockedRun = false;
    // Start is called before the first frame update
    void Start(){
        moveSpeed = 5;
        rb = GetComponent<Rigidbody2D>();
        
        increasedMovement.playerController = this;
    }

    // Update is called once per frame, because of that we shouldn't do physics here.
    void Update()
    {
        ProcessInputs();
        FollowCamera();

        if (increasedMovement == null )
        {
            increasedMovement = GetComponent<IncreasedMovement>();
            if (increasedMovement != null)
            {
                increasedMovement.playerController = this;
            }
        }
    }

    //Called at fixed intervals instead of users frame rate -> Better for physics.
    private void FixedUpdate(){
        Move();
        AimDirection();
    }
    
    

    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal"); // Raw gives u either 0 or 1.
        float moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY);

        // Convert mouse position into Unity coordinate system (World).
        if (Camera.main != null) _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void Move(){
        float actMoveSpeed = increasedMovement != null ? increasedMovement.GetCurrentSpeed() : moveSpeed;
        // Increase speed if shift is pressed or held.
        if(Input.GetKey(KeyCode.LeftShift) && unlockedRun){
            rb.velocity = new Vector2(_moveDirection.x * actMoveSpeed * 1.5f, _moveDirection.y * actMoveSpeed * 1.5f);
        }
        else{
            rb.velocity = new Vector2(_moveDirection.x * actMoveSpeed, _moveDirection.y * actMoveSpeed);
        }

        if (teleport == null) teleport = gameObject.GetComponent<Teleport>();
        if (Input.GetKey(KeyCode.Q) && teleport != null && !teleport.onCooldown && unlockedTeleport){
            teleport.TeleportPlayer();
        }
    }
    
    void AimDirection(){
        // Get direction from player to mouse position.
        Vector2 lookDir = _lookDirection - rb.position;
        // Convert direction to angle.
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // Rotate player to look at mouse position.
        rb.rotation = angle;
    }
    void FollowCamera(){
        var position = transform.position;
        if (Camera.main != null) Camera.main.transform.position = new Vector3(position.x, position.y, -10);
    }

    // Used for collision with a gameobject that changes scenes
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("NextScene")){
            ChangeScene.Instance.moveToNextScene();
        }
        if (other.gameObject.CompareTag("PreviousScene")){
            ChangeScene.Instance.moveToPreviousScene();
        }
    }
    
    
}
