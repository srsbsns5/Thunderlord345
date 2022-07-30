using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    public Transform itemHolder;
    public WeightedRandomList<Transform> lootTable;

    Animator anim;

    public PlayerControls playerInputs;
    private InputAction interact;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }
    private void Awake() 
    {
        playerInputs = new PlayerControls();
    }
    private void OnEnable() 
    {
        interact = playerInputs.Player.Interact;
        interact.Enable();        
    }
    private void OnDisable() 
    {
        interact.Disable();       
    }

    void Update()
    {
        if (playerInputs.Player.Interact.triggered)
        {
            if (isOpen())
            {
                anim.SetTrigger("Close");
                HideItem();
            }
            else
            {
                anim.SetTrigger("Open");
            }
        }
    }

    bool isOpen()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("ChestOpen");
    }

    void HideItem()
    {
        itemHolder.localScale = Vector3.zero;
        itemHolder.gameObject.SetActive(false);
    }
    void ShowItem()
    {
        itemHolder.gameObject.SetActive(true);
    }
}
