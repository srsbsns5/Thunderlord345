using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask playerLayer;
    public Transform destination;
    GameObject objectToTeleport;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            objectToTeleport = other.gameObject;
            print(objectToTeleport);
            objectToTeleport.transform.position = destination.transform.position;    
        }
    }
}
