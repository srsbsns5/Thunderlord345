using UnityEngine;

public class Interactable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.Find("groundCheck").transform.Find("PickupGlow").gameObject.SetActive(true);
            other.GetComponent<PlayerController>().itemToPick = this.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.Find("groundCheck").Find("PickupGlow").gameObject.SetActive(false);
            other.GetComponent<PlayerController>().itemToPick = null;

        }
    }
}
