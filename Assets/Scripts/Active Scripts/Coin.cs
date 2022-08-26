using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
        private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<CoinCollector>().IncreaseCoinCount();

            if (!other.GetComponent<CoinCollector>())
            {
                Debug.LogError("ADD THE COIN COLLECTOR SCRIPT TO PLAYER");
            }
            
            Destroy(gameObject);
        }
    }
}
