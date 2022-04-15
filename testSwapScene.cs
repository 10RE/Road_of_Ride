using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSwapScene : MonoBehaviour
{

    public bool test = false;

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            GetComponent<sceneManager>().swapScene();
            test = false;
        }
    }
}
