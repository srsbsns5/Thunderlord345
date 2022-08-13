using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController charaController;
    public PlayerControls playerInputs;
    private InputAction move;
    private InputAction jump;
    private InputAction interact;
    private InputAction attack;

    [Header("Equipping")]
    public GameObject equippedWeaponPrefab;
    public Transform weaponSlot;
    WeaponController wepaonC;
    public GameObject itemToPick;
    [Header("CHARACTERistics")]
    public Character character;
    float speed = 12f;
    public float maxHealth = 100f;
    float stamina = 50f;
    public float jumpSpeed = 5f;
    GameObject pickupGlow;

    [Header ("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float gravity = -12f;
    Vector3 velocity;

    [Header("UI")]
    public Image healthBar;
    public float currentHealth;
    public Text healthText;

    Vector2 moveDirection = Vector2.zero;
    
    private void Start() 
    {
        speed = character.moveSpeed;
        stamina = character.stamina;      
        maxHealth = character.health;
        currentHealth = maxHealth;
        healthText.text = currentHealth + "/" + maxHealth;

        equippedWeaponPrefab.transform.position = weaponSlot.position;
        equippedWeaponPrefab.transform.SetParent(weaponSlot.transform);
        wepaonC = equippedWeaponPrefab.GetComponent<WeaponController>();

        pickupGlow = transform.Find("groundCheck").Find("PickupGlow").gameObject;
        EventManager.NewItemEquip();
    }
    private void Awake() 
    {
        playerInputs = new PlayerControls();
    }

    private void OnEnable() 
    {
        move = playerInputs.Player.Move;
        move.Enable();
        jump = playerInputs.Player.Jump;
        jump.Enable();
        attack = playerInputs.Player.Fire;
        attack.Enable();
        interact = playerInputs.Player.Interact;
        interact.Enable();
    }
    private void OnDisable() 
    {
        move.Disable();
        jump.Disable();
        interact.Disable();
        attack.Disable();
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
        Vector3 movement =(moveDirection.y * transform.forward) + (moveDirection.x * transform.right);
        charaController.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        charaController.Move(velocity * Time.deltaTime);

        if (playerInputs.Player.Jump.triggered && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }

        #endregion
    
        healthText.text = currentHealth + "/" + maxHealth;

        if (itemToPick != null) PickUpItem();
        else return;

         if (playerInputs.Player.Fire.triggered)
        {
            Attack();
        }
    }

    void PickUpItem()
    {        
        if(playerInputs.Player.Interact.triggered)
        {
            print("Picking Up");
            Destroy(equippedWeaponPrefab.gameObject); //removes previous weapon
            
            equippedWeaponPrefab = itemToPick.gameObject; //changes the equipped weapon object
            itemToPick.transform.Find("interactable").gameObject.SetActive(false);
            itemToPick = null;
            
            pickupGlow.SetActive(false);
            equippedWeaponPrefab.transform.position = weaponSlot.position; //moves picked up item to slot
            equippedWeaponPrefab.transform.SetParent(weaponSlot.transform);
            wepaonC = equippedWeaponPrefab.GetComponent<WeaponController>();  //updates weapon controller
            EventManager.TakeItem += wepaonC.UpdateWeapon; //updates the weapon stats upon new weapon equipped
        }
    }
    void Attack()
    {
        print("Attacking");
    }
    
}
