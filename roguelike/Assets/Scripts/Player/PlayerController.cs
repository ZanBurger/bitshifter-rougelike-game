using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 _moveDirection;
    // Shooting
    private Vector2 _lookDirection;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start(){
        moveSpeed = 5;
    }

    // Update is called once per frame, because of that we shouldn't do physics here.
    void Update(){
        ProcessInputs();
        FollowCamera();
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
        
        // Shoot on left click.
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            weapon.Shoot();
        }
        
        // Convert mouse position into Unity coordinate system (World).
        if (Camera.main != null) _lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void Move(){
        // Increase speed if shift is pressed or held.
        if(Input.GetKey(KeyCode.LeftShift)){
            rb.velocity = new Vector2(_moveDirection.x * moveSpeed * 2, _moveDirection.y * moveSpeed * 2);
        }
        else{
            rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
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
        if (other.gameObject.tag == "SceneChanger"){
            ChangeScene.Instance.moveToScene();
        }
    }
}