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
        if(InRange())
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
    }

    bool isOpen()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("ChestOpen");
    }

    bool InRange()
    {
        GameObject nearestPlayer = FindClosestPlayer();

        Vector3 differenceFromPlayer = transform.position - nearestPlayer.transform.position;
        float distanceFromPlayer = differenceFromPlayer.sqrMagnitude;

        if (distanceFromPlayer <= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private UnityEngine.GameObject FindClosestPlayer()
    {
        UnityEngine.GameObject[] targets;
        targets = UnityEngine.GameObject.FindGameObjectsWithTag("Player");

        UnityEngine.GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (UnityEngine.GameObject active in targets)
        {
            Vector3 diff = active.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = active;
                distance = curDistance;
            }
        }
        return closest;
    }

    void HideItem()
    {
        itemHolder.localScale = Vector3.zero;
        itemHolder.gameObject.SetActive(false);

        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }
    }
    void ShowItem()
    {
        Transform item = lootTable.GetRandom();
        Instantiate(item, itemHolder);
        itemHolder.gameObject.SetActive(true);
    }
}
