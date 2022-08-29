using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Shop : MonoBehaviour 
{
    public GameObject ingameShop;
    public LevelSystem levelSys;
    public HealthSystem currentPlayerHealthSys;
    public HealthSystem otherPlayerHealthSys;
    public CoinCollector playerCoinInventory;
    [SerializeField] int level;
    public Text coinCount;
    public GameObject selectableObject;
    
    [Header("Goods Database")]
    public GameObject[] upgrades;
    private void Start() 
    {
        level = levelSys.level;

        //EventManager.AllowPreWaveActions += GenerateShopItems;
        EventManager.AllowPreWaveActions += ShopActive;
        EventManager.EndPreWaveActions += ForceCloseShop;
    }

    private void Update() 
    {
        level = levelSys.level;
        if (ingameShop.activeInHierarchy) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        coinCount.text = "coins: " + playerCoinInventory.inventoryCoins;
    }

    void ShopActive()
    {
        if (!currentPlayerHealthSys.isDead)
        {
            if (selectableObject!=null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(selectableObject);
            }
            ingameShop.SetActive(true);
        }
    }

    void GenerateShopItems()
    {
        switch (level)
        {
            case 1:
                for (int i = 0; i < 5; i++ ) //first 4 upgrades will be available to player
                upgrades[i].SetActive(true);
                
                break;

            default:
                break;
        }
    }

    void ForceCloseShop()
    {
        ingameShop.SetActive(false);
        if (selectableObject!=null)
        {   EventSystem.current.SetSelectedGameObject(null);}
    }
}