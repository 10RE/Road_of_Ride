using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHandsCollision : MonoBehaviour
{

    public steer vehicleSteer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Hit1");
        if (other.tag == "LHand"
             && (
              OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)
              || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)
             )
            )
        {
            Debug.Log("Hit");
            vehicleSteer.setLFreeze(true);
            other.GetComponent<Collider>().isTrigger = false;
            other.GetComponent<Collider>().enabled = false;
            //other.gameObject.SetActive(false);
        }

        if (other.tag == "RHand"
             && (
              OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)
              || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)
             )
            )
        {
            vehicleSteer.setRFreeze(true);
            other.GetComponent<Collider>().isTrigger = false;
            other.GetComponent<Collider>().enabled = false;
            //other.gameObject.SetActive(false);
        }
    }
}
