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

        currentHP = shop.healthSys.currentHealth;
        maxHP = shop.healthSys.maxHealth;
    }

    public void ResetLimit()
    {
        currentTimesBought = buyLimit;
    }

    public void TimesBoughtTracker()
    {
        currentTimesBought--;

        if(currentTimesBought <= buyLimit) //if player has reached the buy limit, disable the button
        {
            buttonImage.color = new Color (255,255,255, 55);
            gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void SlightHeal(float increaseAmount)
    {
        increaseAmount = shop.healthSys.maxHealth / 5;
        currentHP += increaseAmount;

        if (currentHP > maxHP) currentHP = maxHP;
    }
    public void ModerateHeal(float increaseAmount)
    {
        increaseAmount = shop.healthSys.maxHealth / 3;
        currentHP += increaseAmount;

        if (currentHP > maxHP) currentHP = maxHP;
    }
    public void FullHeal()
    {
        currentHP = maxHP;   
    }

    public void ReviveHalf()
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