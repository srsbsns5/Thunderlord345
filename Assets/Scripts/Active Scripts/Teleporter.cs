using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    GameObject objectToTeleport;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            //objectToTeleport = other.gameObject;
            print(other.gameObject.name);
            print(destination.name);
            other.gameObject.transform.position = destination.position;    
        }
    }
}
