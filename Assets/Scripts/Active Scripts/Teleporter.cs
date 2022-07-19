using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject destination;
    [SerializeField] GameObject objectToTeleport;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            objectToTeleport = other.gameObject;
            print(objectToTeleport.name);
            print(destination.name);
            StartCoroutine(Teleport());             
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("TELEPORT PLEASE");
        objectToTeleport.transform.position = destination.transform.position;   
    }
    
}
