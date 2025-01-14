using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    public float jumpforce;
    public float jumpcooldown;
    public float airMultiplier;
    bool readytojump;

    [Header("Keybinds")] 
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")] 
    public float playerHeight;

    public LayerMask whatIsGround;
     bool grounded;

     public Transform orientation;

     float horizontalInput;
     float verticalInput;

     Vector3 moveDirection;

     Rigidbody rb;
     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Assign the Rigidbody component to rb
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;



    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && readytojump && grounded)
        {
            readytojump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpcooldown);
        }

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if(grounded)
            rb.AddForce(moveDirection.normalized*moveSpeed*10f,ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized*moveSpeed*10f* airMultiplier,ForceMode.Force);
            
        


    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(transform.up*jumpforce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readytojump = true;
    }




}
