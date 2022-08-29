using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public LayerMask playerLayer;
    RaycastHit hit;

    [SerializeField] UnityEngine.GameObject objectToTeleport;
    /*
    private void Update() 
    {
        Physics.Raycast(transform.position, Vector3.up, out hit, 3, playerLayer);
        Debug.DrawRay(transform.position,Vector3.up, Color.green);

        if (hit.collider != null)
        {
            objectToTeleport = hit.collider.gameObject;
            StartCoroutine(Teleport());
        }
    }
    */
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            objectToTeleport = other.gameObject;
            StartCoroutine("Teleport");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            objectToTeleport = null;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2);
        objectToTeleport.SetActive(false);
        yield return null;
        objectToTeleport.transform.position = destination.position;
        yield return null;
        objectToTeleport.SetActive(true);
        yield return null;
        objectToTeleport = null;
    }
    
}
