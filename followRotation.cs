using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followRotation : MonoBehaviour
{

    public GameObject objectToFollow;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = objectToFollow.transform.eulerAngles - offset;
    }
}
