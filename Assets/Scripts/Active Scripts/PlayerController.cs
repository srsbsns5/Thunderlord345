using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController charaController;
    
    public PlayerControls playerInputs;
    private InputAction move;

    [Header("CHARACTERistics")]
    public Character character;
    float speed = 12f;
    float health = 100f;
    float stamina = 50f;
    public float jumpSpeed = 5f;

    [Header ("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float gravity = -12f;
    Vector3 velocity;

    Vector2 moveDirection = Vector2.zero;
    private void Start() 
    {
        speed = character.moveSpeed;
        health = character.health;
        stamina = character.stamina;      
    }
    private void Awake() {
        playerInputs = new PlayerControls();
    }

    private void OnEnable() 
    {
        move = playerInputs.Player.Move;
        move.Enable();
    }
    private void OnDisable() 
    {
        move.Disable();
    }

    void Update()
    {
        #region player physics
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        moveDirection = move.ReadValue<Vector2>();

        charaController.Move(moveDirection * speed * Time.deltaTime);

        //velocity.y += gravity * Time.deltaTime;
        //charaController.Move(velocity * Time.deltaTime);

        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }*/

        #endregion

       
    }
}
