using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.Find("groundCheck").transform.Find("PickupGlow").gameObject.SetActive(true);
            if (other.GetComponent<PlayerController>() != null)
            {
                other.GetComponent<PlayerController>().itemToPick = gameObject.transform.parent.gameObject;
            } else if (other.GetComponent<PlayerTwoController>() != null)
            {
                other.GetComponent<PlayerTwoController>().itemToPick = gameObject.transform.parent.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.Find("groundCheck").Find("PickupGlow").gameObject.SetActive(false);
            if (other.GetComponent<PlayerController>() != null)
            {
                other.GetComponent<PlayerController>().itemToPick = null;
            } else if (other.GetComponent<PlayerTwoController>() != null)
            {
                other.GetComponent<PlayerTwoController>().itemToPick = null;
            }
        }
    }

}
