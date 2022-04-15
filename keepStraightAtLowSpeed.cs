using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepStraightAtLowSpeed : MonoBehaviour
{

    public float speedThresh = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude < speedThresh)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }
}
