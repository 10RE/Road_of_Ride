using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject objectToFollow;
    public GameObject cameraFollowing;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
        //cameraFollowing.transform.rotation = objectToFollow.transform.rotation;
        //transform.rotation = objectToFollow.transform.rotation;
    }
}
