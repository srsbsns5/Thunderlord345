using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject t_destination;
    GameObject objectToTeleport;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            objectToTeleport = other.gameObject;

            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        objectToTeleport.transform.position = t_destination.transform.position;   
        Debug.Log("TELEPORT PLEASE");
        print(objectToTeleport);
        print(t_destination.name);
    }
    
}
