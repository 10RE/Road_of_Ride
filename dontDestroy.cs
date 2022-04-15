using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] objs;

    void Awake()
    {
        foreach (GameObject obj in objs)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
