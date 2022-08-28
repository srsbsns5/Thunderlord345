using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Image buttonImage;
    public Shop shop;

    public AudioSource buySuccess;
    public AudioSource buyFail;

    public GameObject chest;
    public GameObject chestCam;
    public GameObject chestItemHolder;
    public GameObject equipItem;
    public GameObject discardItem;

    float currentHP;
    float maxHP;
    private void Awake() 
    {
        currentHP = shop.currentPlayerHealthSys.currentHealth;
        maxHP = shop.currentPlayerHealthSys.maxHealth;
    }


    public void SlightHeal(int cost)
    {
        print(shop.playerCoinInventory.inventoryCoins);
        float increaseAmount;
        if (shop.playerCoinInventory.inventoryCoins >= cost)
        {
            increaseAmount = Mathf.RoundToInt(shop.currentPlayerHealthSys.maxHealth / 5);
            shop.currentPlayerHealthSys.IncreasePlayerHealth(increaseAmount);
            print(increaseAmount);

            shop.playerCoinInventory.inventoryCoins -= cost;     
            buySuccess.Play();                  
        }
        else {buyFail.Play();}
    }
    public void ModerateHeal(int cost)
    {
        float increaseAmount;
        if (shop.playerCoinInventory.inventoryCoins >= cost)
        {
            increaseAmount = shop.currentPlayerHealthSys.maxHealth / 3;
            shop.currentPlayerHealthSys.IncreasePlayerHealth(increaseAmount);

            shop.playerCoinInventory.inventoryCoins -= cost;
            buySuccess.Play();            
        }
        else {buyFail.Play();}
    }
    public void FullHeal(int cost)
    {
        if (shop.playerCoinInventory.inventoryCoins >= cost)
        {
            float increaseAmount;
            increaseAmount = 9999;
            shop.currentPlayerHealthSys.IncreasePlayerHealth(increaseAmount);

            shop.playerCoinInventory.inventoryCoins -= cost;
            buySuccess.Play();
        }
        else {buyFail.Play();}
    }

    public void Revive(int cost)
    {
        if (shop.otherPlayerHealthSys.isDead)
        {
            shop.otherPlayerHealthSys.PlayerAlive();
            shop.otherPlayerHealthSys.IncreasePlayerHealth(Mathf.RoundToInt(shop.otherPlayerHealthSys.maxHealth / 2));
            shop.playerCoinInventory.inventoryCoins -= cost;
            buySuccess.Play();
        }
        else {buyFail.Play();}
    }

    public void WeaponGacha(int cost)
    {
        if (shop.playerCoinInventory.inventoryCoins >= cost)
        {
            chest.SetActive(true);
            chest.gameObject.GetComponent<Chest>().OpenChest();
        }
        else {buyFail.Play();}
    }
    public void P2EquipWeapon()
    {
        FindObjectOfType<PlayerTwoController>().itemToPick = chestItemHolder.transform.GetChild(0).gameObject;
        FindObjectOfType<PlayerTwoController>().PickUpItem();

        chest.gameObject.GetComponent<Chest>().CloseChest();
    }

    public void P1EquipWeapon()
    {
        FindObjectOfType<PlayerController>().itemToPick = chestItemHolder.transform.GetChild(0).gameObject;
        FindObjectOfType<PlayerController>().PickUpItem();

        chest.gameObject.GetComponent<Chest>().CloseChest();
    }

    public void DiscardWeapon()
    {
        chest.gameObject.GetComponent<Chest>().CloseChest();
    }
    private void OnEnable()
    {
        if (chestCam!=null)
        chestCam.SetActive(true);
    }

    private void OnDisable() 
    {
        if (chestCam!=null)
        chestCam.SetActive(false);
    }
}