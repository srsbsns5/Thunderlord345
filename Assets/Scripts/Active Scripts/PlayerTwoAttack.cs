using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerTwoAttack : MonoBehaviour 
{
    public Player2Controls playerInputBindings;
    public Animator anim;
    private InputAction attack;
    private void Awake() 
    {
        playerInputBindings = new Player2Controls();
    }

    private void OnEnable()
    {
        attack = playerInputBindings.Player.Attack;
        attack.Enable();
    }

    private void OnDisable() 
    {
        attack.Disable();
    }

    private void Update() 
    {
        if (playerInputBindings.Player.Attack.triggered)  
        {
            print("Attacking");
            //Attack();
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
}