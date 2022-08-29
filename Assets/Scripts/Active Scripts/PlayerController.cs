using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Controls")]
    public CharacterController charaController;
    public PlayerControls playerInputBindings;
    private InputAction move;
    private InputAction jump;
    private InputAction escape;
    [Header("Equipping")]
    public GameObject equippedWeaponPrefab;
    public Transform weaponSlot;
    WeaponController wepaonC;
    public GameObject itemToPick;
    [Header("CHARACTERistics")]
    public bool canMove = true;
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
    Vector2 moveDirection = Vector2.zero;

    Animator anim;
    [SerializeField] GameObject pause;
    
    private void Start() 
    {
        speed = character.moveSpeed;
        stamina = character.stamina;
        anim = GetComponent<Animator>();

        equippedWeaponPrefab.transform.position = weaponSlot.position;
        equippedWeaponPrefab.transform.SetParent(weaponSlot.transform);
        wepaonC = equippedWeaponPrefab.GetComponent<WeaponController>();

        pickupGlow = transform.Find("groundCheck").Find("PickupGlow").gameObject;
        EventManager.NewItemEquip();
    }
    private void Awake() 
    {
        playerInputBindings = new PlayerControls();
    }

    private void OnEnable() 
    {
        move = playerInputBindings.Player.Move;
        move.Enable();
        jump = playerInputBindings.Player.Jump;
        jump.Enable();
        escape = playerInputBindings.Player.Escape;
        escape.Enable();
    }
    private void OnDisable() 
    {
        move.Disable();
        jump.Disable();
        escape.Disable();
    }

    void Update()
    {
    if(canMove)
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

        if (moveDirection.x != 0 || moveDirection.y != 0) { anim.SetBool("isMoving",true); }
        else anim.SetBool("isMoving",false);

        velocity.y += gravity * Time.deltaTime;
        charaController.Move(velocity * Time.deltaTime);

        if (playerInputBindings.Player.Jump.triggered && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
            anim.SetBool("isJumping", true);
        }   
            else
            {
                anim.SetBool("isJumping", false);
            }
    }

        #endregion

        if (playerInputBindings.Player.Escape.triggered)
        {
            if (pause.activeInHierarchy)
            {
                pause.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                EventSystem.current.SetSelectedGameObject(pause.transform.Find("retry").gameObject);
            }   
            else 
            {
                pause.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    public void PickUpItem()
    {
        if (itemToPick != null)
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
}
