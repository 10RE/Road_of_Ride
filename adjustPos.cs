using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustPos : MonoBehaviour
{
    public Vector3 ratio;
    public Vector3 defaultRotation;
    public Transform sourceObject;
    public Transform targetObject;
    //public bikeValStore valueDict;

    // Start is called before the first frame update
    void Start()
    {
        //parentTransform = transform.parent;
        defaultRotation = targetObject.transform.localEulerAngles;
    }

    // Update is called once per frame
    public void Step()
    {
        float localAngle = sourceObject.localEulerAngles.y;
        if (localAngle > 180)
        {
            localAngle -= 360;
        }
        //valueDict.Save("rot", localAngle);
        targetObject.transform.localRotation = Quaternion.Euler(defaultRotation + ratio * localAngle);
    }
}
