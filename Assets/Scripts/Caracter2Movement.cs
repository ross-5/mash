using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Caracter2Movement : MonoBehaviour
{
    //private CharacterController controller;
    //private Vector3 playerVelocity;
    //private bool groundedPlayer;
    public Rigidbody2D rb;
    private float playerSpeed = 2.0f;
    

    public InputAction playerControls;
    private Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction jump;
    //private bool jumped = false;

    private void Awake()
    {
        //playerControls = new Player2InputActions();
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        playerControls.Enable();
       
       
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);
    }
}
