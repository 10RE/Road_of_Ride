using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrTour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject ui;
    void OnTriggerEnter(Collider other)  {
        Debug . Log(other .tag );
        if(other.tag .Contains("Hand"))
ui .SetActive(true );
    }
      void OnTriggerExit(Collider other)  {
           if(other.tag .Contains("Hand"))
ui .SetActive(false );
    }
}
