using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalTest : MonoBehaviour
{
    //DONE
    public Text txt;
    public GameObject Destination;
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            txt.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                col.GetComponentInChildren<CharacterController>().enabled = false;
                col.gameObject.transform.position = Destination.transform.position;
                txt.gameObject.SetActive(false);
                col.GetComponentInChildren<CharacterController>().enabled = true;
            }
        }
    }
}
