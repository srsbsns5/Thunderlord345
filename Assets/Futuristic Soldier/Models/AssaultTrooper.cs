using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultTrooper : MonoBehaviour
{
    Animator anim;
    CharacterController controller;

    public float speed = 5f;
    public float rotationRate = 180f;
    public float jumpForce = 6f;

    Vector3 velocity;//used to store gravity to apply to the player.

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    void HandleLook()
    {
         transform.Rotate(0, Input.GetAxis("Mouse X") * rotationRate * Time.deltaTime,0);
    }

    void HandleMovement()
    {
        //Calculate acceleration due to gravity
        velocity += Physics.gravity * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && controller.isGrounded){
            velocity += transform.up * jumpForce;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }

        //Movement controls
        Vector3 v = new Vector3(
            Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        anim.SetFloat("MoveX", v.x);
        anim.SetFloat("MoveY", v.z);
        //anim.SetBool("isGrounded", controller.isGrounded);

        controller.Move((transform.TransformDirection(v.normalized) * speed + velocity) * Time.deltaTime);

        //Null velocity if player hits the ground
        if (controller.isGrounded) velocity = Vector3.zero;
    }


}
