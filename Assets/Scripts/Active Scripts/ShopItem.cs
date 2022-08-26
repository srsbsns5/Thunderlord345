using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public int buyLimit;
    public int currentTimesBought;
    public Image buttonImage;
    public Shop shop;

    float currentHP;
    float maxHP;
    private void OnEnable() 
    {
        currentTimesBought = buyLimit;
        EventManager.AllowPreWaveActions += ResetLimit;

        currentHP = shop.currentPlayerHealthSys.currentHealth;
        maxHP = shop.currentPlayerHealthSys.maxHealth;
    }

    public void ResetLimit()
    {
        currentTimesBought = buyLimit;
    }

    public void BuyableTracker()
    {
        currentTimesBought--;

        if(currentTimesBought <= buyLimit) //if player has reached the buy limit, disable the button
        {
            buttonImage.color = new Color (255,255,255, 55);
            gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void SlightHeal(float increaseAmount, int cost)
    {
        if (shop.playerCoinInventory.inventoryCoins >= cost)
        {
            increaseAmount = shop.currentPlayerHealthSys.maxHealth / 5;
            currentHP += increaseAmount;

            if (currentHP > maxHP) currentHP = maxHP;
            shop.playerCoinInventory.inventoryCoins -= cost;           
        }
        
    }
    public void ModerateHeal(float increaseAmount, int cost)
    {
        if (shop.playerCoinInventory.inventoryCoins >= cost)
        {
            increaseAmount = shop.currentPlayerHealthSys.maxHealth / 3;
            currentHP += increaseAmount;

            if (currentHP > maxHP) currentHP = maxHP;
            shop.playerCoinInventory.inventoryCoins -= cost;
        }
    }
    public void FullHeal(int cost)
    {
        if (shop.playerCoinInventory.inventoryCoins >= cost)
        {
            currentHP = maxHP;   
            shop.playerCoinInventory.inventoryCoins -= cost;
        }
    }

    public void ReviveHalf(int cost)
    {
        
    }

    /* Upgrades to add
    recover teammate to half health
    recover teammate to full heatlh
    weapon gacha 1
    weapon gacha 2
    weapon gacha 3
    */
}