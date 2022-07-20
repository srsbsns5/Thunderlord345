using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;

    [SerializeField] GameObject objectToTeleport;

    private void OnTriggerEnter(Collider other) 
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            objectToTeleport = player.gameObject;
            StartCoroutine("Teleport");
        }
    }

    IEnumerator Teleport()
    {
        Debug.Log("TELEPORT PLEASE");

        objectToTeleport.SetActive(false);
        yield return null;
        objectToTeleport.transform.position = destination.position;
        yield return null;
        objectToTeleport.SetActive(true);
        yield return null;
        objectToTeleport = null;   
    }
    
}
