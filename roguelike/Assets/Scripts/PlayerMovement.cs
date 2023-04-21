using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 _moveDirection;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        moveSpeed = 5;

    }

    // Update is called once per frame, because of that we shouldn't do physics here.
    void Update(){
        ProccesInputs();
    }

    //Called at fixed intervals instead of users frame rate -> Better for physics.
    private void FixedUpdate(){
        Move();
    }

    void ProccesInputs(){
        float moveX = Input.GetAxisRaw("Horizontal"); // Raw gives u either 0 or 1.
        float moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY);
    }

    void Move(){
        rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }
}