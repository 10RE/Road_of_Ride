using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAccordingToSpeed : MonoBehaviour
{

    public Rigidbody referenceObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = referenceObject.velocity.magnitude;
        transform.Rotate(0, 0, speed);
    }
}
