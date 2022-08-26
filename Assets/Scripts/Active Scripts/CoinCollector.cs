using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int inventoryCoins;
    public Text dynamicCoinCount;
    
    public void UpdateCoinCountUI()
    {
        if (dynamicCoinCount != null)
        dynamicCoinCount.text = "" + inventoryCoins;
    }

    public void IncreaseCoinCount()
    {
        EventManager.CoinCountUp();
        inventoryCoins++;
     
        UpdateCoinCountUI();
    }
}
