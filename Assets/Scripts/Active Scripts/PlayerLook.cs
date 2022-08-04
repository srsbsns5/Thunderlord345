using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float senstivity = 100f;
    public Transform playerTrans;
    public PlayerControls playerInputs;
    private InputAction look;
    private InputAction interact;


    float xRotation = 0f;
    Vector2 lookDirection;
    private void Awake() 
    {
        playerInputs = new PlayerControls();
    }

    private void OnEnable() 
    {
        look = playerInputs.Player.Look;
        look.Enable();
        interact = playerInputs.Player.Interact;
        interact.Enable(); 
    }
    private void OnDisable() 
    {
        look.Disable();
        interact.Disable();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() 
    {
        lookDirection = look.ReadValue<Vector2>();

        float mouseX = lookDirection.x * senstivity * Time.deltaTime;
        float mouseY = lookDirection.y * senstivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -60f, 40f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        playerTrans.Rotate(Vector3.up * mouseX);
    }


    [SerializeField] LayerMask interactableLayer;
    [SerializeField] float pickupRange;
    [SerializeField] RaycastHit hit;


}
