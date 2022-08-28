using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    public Transform itemHolder;
    public WeightedRandomList<Transform> lootTable;
    public GameObject itemLight;

    Animator anim;

    public PlayerControls playerInputs;
    private InputAction interact;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }
    public void OpenChest()
    {
        anim.SetTrigger("Open");
    }

    public void CloseChest()
    {
        anim.SetTrigger("Close");
        itemLight.SetActive(false);
        HideItem();
    }

    public bool isOpen()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("ChestOpen");
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
        itemLight.SetActive(true);
        Transform item = lootTable.GetRandom();
        Instantiate(item, itemHolder);
        itemHolder.gameObject.SetActive(true);
    }
}
