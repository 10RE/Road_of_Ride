using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithController : MonoBehaviour
{

    public float speed = 1f;
    public float rotateAngle = 30f;
    private bool rotateFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveValV = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch)[1];
        float moveValH = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch)[0];
        if (Mathf.Abs(moveValV) > 0.1 || Mathf.Abs(moveValH) > 0.1)
        {
            transform.Translate(moveValH / 100 * speed, 0, moveValV / 75 * speed);
        }
        float rotateVal = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch)[0];
        if (Mathf.Abs(rotateVal) > 0.5 && !rotateFlag)
        {
            transform.Rotate(0f, rotateVal / Mathf.Abs(rotateVal) * rotateAngle, 0f, Space.Self);
            rotateFlag = true;
        }
        if (rotateFlag && Mathf.Abs(rotateVal) < 0.1)
        {
            rotateFlag = false;
        }
    }
}
