using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour 
{
    public PlayerControls playerInputBindings;
    public Animator anim;
    private InputAction attack;
    private void Awake() 
    {
        playerInputBindings = new PlayerControls();
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
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
}