using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public int buyLimit;
    public int currentTimesBought;
    public Image buttonImage;
    private void OnEnable() 
    {
        currentTimesBought = buyLimit;
        EventManager.AllowPreWaveActions += ResetLimit;
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

    public void HealthUpgrade(int increaseAmount)
    {
        //make it so players can increase their maxhealth here
    }

    /* Upgrades to add
    increase max health slightly
    increase max health moderately
    heal slightly
    heal moderately
    heal fully
    recover teammate to half health
    recover teammate to full heatlh
    increase player strength slightly
    increase player strength moderately
    */
}