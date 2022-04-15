using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixRotation : MonoBehaviour
{
    public Vector3 ratio;
    public int rotateLimit;
    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Step()
    {
        float y = targetObject.transform.localEulerAngles.y;
        if (y > 180)
        {
            y -= 360;
        }
        if (y > rotateLimit) {
            y = rotateLimit;
        }
        else if (y < -rotateLimit)
        {
            y = -rotateLimit;
        }
        Vector3 localRotate = ratio * y;
        localRotate.z = Mathf.Abs(localRotate.z);
        targetObject.transform.localRotation = Quaternion.Euler(localRotate);
    }
}
