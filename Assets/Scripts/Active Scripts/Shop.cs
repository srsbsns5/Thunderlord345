using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour 
{
    public GameObject ingameShop;
    public LevelSystem levelSys;
    public HealthSystem healthSys;
    [SerializeField] int level;
    
    [Header("Goods Database")]
    public GameObject[] upgrades;
    private void Start() 
    {
        level = levelSys.level;

        //EventManager.AllowPreWaveActions += GenerateShopItems;
        EventManager.AllowPreWaveActions += ShopActive;
        EventManager.EndPreWaveActions += ForceCloseShop;
    }

    void ShopActive()
    {
        ingameShop.SetActive(true);
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
    }
}