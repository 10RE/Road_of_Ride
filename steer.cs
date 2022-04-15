using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steer : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject rightHandTarget;

    public GameObject leftHand;
    public GameObject leftHandTarget;

    public float accelerationMulti = 1f;
    public float turningMulti = 1f;
    public float brakeMulti = 1f;

    public float rotateOffset;
    public float accelerateOffset;

    public GameObject Vehicle;
    private Rigidbody vehicleRigidBody;

    public GameObject accelerateHandle;
    private Quaternion handlRotation;
    private Vector3 accelerateStartRotation;
    private bool accelerateStartFlag = false;

    public GameObject brakeHandleR;
    public GameObject brakeHandleL;

    public GameObject rpmMeter;
    public GameObject speedMeter;

    private bool engineFirstInFlag = true;

    public float maxSpeed = 20;

    public GameObject vehicleBody;

    [SerializeField] WheelCollider frontWheelL;
    [SerializeField] WheelCollider frontWheelR;
    [SerializeField] WheelCollider backWheel;

    public GameObject objectToSteer;

    private bool LFreeze = false;
    private bool RFreeze = false;

    private float initRpm = 0;

    //public bikeValStore valueDict;

    public void setLFreeze(bool b)
    {
        LFreeze = b;
    }
    public void setRFreeze(bool b)
    {
        RFreeze = b;
    }

    void resetHandPosition(GameObject hand)
    {
        hand.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    void ReleaseLeftHand()
    {
        leftHand.SetActive(true);
        LFreeze = false;
        leftHand.GetComponent<Collider>().enabled = true;
        leftHand.GetComponent<Collider>().isTrigger = true;
        resetHandPosition(leftHand);
    }

    void ReleaseRightHand()
    {
        rightHand.SetActive(true);
        RFreeze = false;
        rightHand.GetComponent<Collider>().enabled = true;
        rightHand.GetComponent<Collider>().isTrigger = true;
        resetHandPosition(rightHand);
    }

    // Start is called before the first frame update
    void Start()
    {
        vehicleRigidBody = Vehicle.GetComponent<Rigidbody>();
        handlRotation = accelerateHandle.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (LFreeze && RFreeze)
        {
            if (engineFirstInFlag)
            {
                GetComponent<playBikeAudios>().SlideInAndStartEngine();
                engineFirstInFlag = false;
                initRpm = 20;
            }
            //leftHand.transform.position = leftHandTarget.transform.position;
            if (
                OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch)
                || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch)
                )
            {
                if (GetComponent<Rigidbody>().velocity.magnitude < 1)
                {
                    LFreeze = false;
                    RFreeze = false;
                    GetComponent<enterRideMode>().ExitRideMode();
                }
            }
        }
        else
        {
            if (!engineFirstInFlag)
            {
                GetComponent<playBikeAudios>().StopEngine();
                engineFirstInFlag = true;
                initRpm = 0;
            }
            frontWheelL.brakeTorque = 100;
            frontWheelR.brakeTorque = 100;
            backWheel.brakeTorque = 100;
        }

        Quaternion handleRot = new Quaternion(0f, 0f, 0f, 0f);

        if (RFreeze)
        {
            //handleRot = Quaternion.Euler(0, Mathf.RoundToInt(rightHand.transform.parent.transform.rotation.eulerAngles.y - rotateOffset), 0);

            //Quaternion handleRot = Quaternion.Euler(0, 0, Mathf.RoundToInt(rightHand.transform.parent.transform.rotation.eulerAngles.z + accelerateOffset));

            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)
                && OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)
                )
            {
                if (!accelerateStartFlag)
                {
                    accelerateStartRotation = rightHand.transform.parent.transform.localEulerAngles;
                    accelerateStartFlag = true;
                }
                else
                {
                    float localAngle = rightHand.transform.parent.transform.rotation.eulerAngles.z - accelerateStartRotation.z;
                    if (localAngle < 0)
                    {
                        localAngle += 360;
                    }
                    if (localAngle > 250)
                    {
                        localAngle -= 360;
                    }
                    float accelerateVal = Mathf.RoundToInt(localAngle + accelerateOffset);
                    if (accelerateVal > 60)
                    {
                        accelerateVal = 60;
                    }
                    else if (accelerateVal < 0)
                    {
                        accelerateVal = 0;
                    }
                    backWheel.motorTorque = -accelerateVal * 8 * accelerationMulti;
                    accelerateHandle.transform.localEulerAngles = handlRotation.eulerAngles - new Vector3(0, 0, accelerateVal);
                }
            }
            else
            {
                accelerateStartFlag = false;
                backWheel.motorTorque = 0;
                accelerateHandle.transform.localEulerAngles = handlRotation.eulerAngles;
                frontWheelL.brakeTorque = 10;
                frontWheelR.brakeTorque = 10;
            }
            float RTriggerDegree = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
            frontWheelL.brakeTorque = RTriggerDegree * 100 * brakeMulti;
            frontWheelR.brakeTorque = RTriggerDegree * 100 * brakeMulti;
            brakeHandleR.transform.localEulerAngles = new Vector3(0f, RTriggerDegree * 15, 0f);

            //Vector3 movement = new Vector3(- accelerateVal * 0.001f * acceleration, 0, leanAngle * 0.01f * turning);
            //Vehicle.transform.Translate(movement * accelerateVal * Time.deltaTime);
        }
        else
        {
            backWheel.motorTorque = 0;
            accelerateHandle.transform.localEulerAngles = handlRotation.eulerAngles;
            frontWheelL.brakeTorque = 0;
            frontWheelR.brakeTorque = 0;
        }
        if (LFreeze)
        {
            handleRot = Quaternion.Euler(0, leftHand.transform.parent.transform.rotation.eulerAngles.y + rotateOffset, 0);

            float LTriggerDegree = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
            backWheel.brakeTorque = LTriggerDegree * 100 * brakeMulti;
            brakeHandleL.transform.localEulerAngles = new Vector3(0f, -LTriggerDegree * 15, 0f);
            //GetComponent<fixRotation>().UpdateRotation();
            //GetComponent<adjustPos>().UpdateRotation();
        }
        objectToSteer.transform.rotation = handleRot;
        float leanAngle = vehicleBody.transform.rotation.eulerAngles.x;
        if (leanAngle > 180)
        {
            leanAngle -= 360;
        }
        //if ()
        //frontWheelL.motorTorque = acceleration;
        //frontWheelR.motorTorque = acceleration;
        //backWheel.motorTorque = -acceleration;
        //Debug.Log(backWheel.motorTorque);
        //float testAngle = vehicleBody.transform.eulerAngles.x;
        //if (testAngle > 180)
        //{
        //    testAngle -= 360;
        //}
        frontWheelL.steerAngle = leanAngle * 10 / 2;
        frontWheelR.steerAngle = leanAngle * 10 / 2;
        //backWheel.steerAngle = - leanAngle * 10 / 2;

        //frontWheelL.steerAngle = valueDict.Get("rot") * 10 / 2;
        //frontWheelR.steerAngle = valueDict.Get("rot") * 10 / 2;
        //backWheel.steerAngle = -Vehicle.transform.eulerAngles.z * 10 / 2;
        /*
        if (brake > 0)
        {
            frontWheelL.brakeTorque = 100f;
            frontWheelR.brakeTorque = 100f;
            backWheel.brakeTorque = 100f;
        }
        else
        {
            frontWheelL.brakeTorque = 0f;
            frontWheelR.brakeTorque = 0f;
            backWheel.brakeTorque = 0f;
        }
        */

        rpmMeter.transform.localEulerAngles = new Vector3(Mathf.Lerp(rpmMeter.transform.localEulerAngles.x, -backWheel.motorTorque * 1.2f + initRpm, 0.1f), 0f, 0f);
        speedMeter.transform.localEulerAngles = new Vector3(GetComponent<Rigidbody>().velocity.magnitude * 10, 0f, 0f);

        if (GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }

        GetComponent<playBikeAudios>().UpdatePitch( - backWheel.motorTorque / 300);
        GetComponent<fixRotation>().Step();
        GetComponent<adjustPos>().Step();
        
    }
}
