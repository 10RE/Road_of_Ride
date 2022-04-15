using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenu : MonoBehaviour
{

    public GameObject startMenuCanvas;
    public bool showTutorial = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<moveWithController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch)
            || OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch)
            || OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch)
            || OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch)
            )
        {
            GetComponent<moveWithController>().enabled = true;
            GetComponent<startMenu>().enabled = false;
            startMenuCanvas.SetActive(false);
            if (showTutorial)
            {
                StartCoroutine(GetComponent<tutorial>().PlayPage());
            }
        }
    }
}
