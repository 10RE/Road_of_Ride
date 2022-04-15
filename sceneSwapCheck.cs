using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneSwapCheck : MonoBehaviour
{

    public sceneManager sman;

    // Update is called once per frame

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "sceneSwap")
        {
            sman.swapScene();
        }
    }
    
    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(1f);
        sman.swapScene();
    }
}
