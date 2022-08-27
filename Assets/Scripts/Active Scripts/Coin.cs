using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource audioS;
    private void OnEnable() 
    {
        audioS = GameObject.FindGameObjectWithTag("Enemy 2").GetComponent<AudioSource>();
        Destroy(gameObject, 20f);    
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<CoinCollector>().IncreaseCoinCount();
            audioS.Play();

            if (!other.GetComponent<CoinCollector>())
            {
                Debug.LogError("ADD THE COIN COLLECTOR SCRIPT TO PLAYER");
            }
            
            Destroy(gameObject);
        }
    }
}
