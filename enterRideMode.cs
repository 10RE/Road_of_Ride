using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterRideMode : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject playerController;
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public Vector3 getOffOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void resetHandPosition(GameObject hand)
    {
        hand.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    void ReleaseLeftHand()
    {
        leftHand.SetActive(true);
        leftHand.GetComponent<Collider>().enabled = true;
        leftHand.GetComponent<Collider>().isTrigger = true;
        resetHandPosition(leftHand);
    }

    void ReleaseRightHand()
    {
        rightHand.SetActive(true);
        rightHand.GetComponent<Collider>().enabled = true;
        rightHand.GetComponent<Collider>().isTrigger = true;
        resetHandPosition(rightHand);
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "LHand"
             && (
              OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)
              || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch)
             ))
             ||
             (other.tag == "RHand"
             && (
              OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)
              || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)
             ))
            )
        {
            GetComponent<steer>().setLFreeze(true);
            GetComponent<steer>().setRFreeze(true);
            rightHand.GetComponent<Collider>().isTrigger = false;
            rightHand.GetComponent<Collider>().enabled = false;
            leftHand.GetComponent<Collider>().isTrigger = false;
            leftHand.GetComponent<Collider>().enabled = false;
            //playerController.GetComponent<CapsuleCollider>().enabled = false;
            //playerController.GetComponent<Rigidbody>().isKinematic = true;
            playerController.transform.parent = transform;
            playerController.transform.localEulerAngles = targetRotation;
            playerController.transform.localPosition = targetPosition;
            playerController.GetComponent<moveWithController>().enabled = false;
            //other.gameObject.SetActive(false);
        }
    }

    public void ExitRideMode()
    {
        ReleaseLeftHand();
        ReleaseRightHand();
        playerController.transform.parent = null;
        playerController.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        //playerController.transform.Translate(getOffOffset);
        //playerController.GetComponent<CapsuleCollider>().enabled = true;
        //playerController.GetComponent<Rigidbody>().isKinematic = false;
        playerController.GetComponent<moveWithController>().enabled = true;
    }
}
