using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController charaController;
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

    private void Start() 
    {
        speed = character.moveSpeed;
        health = character.health;
        stamina = character.stamina;      
    }
    void Update()
    {
        #region player physics
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move =  transform.right * x + transform.forward * z;

        charaController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        charaController.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }

        #endregion

       
    }
}
