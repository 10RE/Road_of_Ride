using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikeValStore : MonoBehaviour
{

    private Dictionary<string, float> dict;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(string s, float v)
    {
        dict[s] = v;
    }

    public float Get(string s)
    {
        if (dict.ContainsKey(s))
        {
            return dict[s];
        }
        return 0;
    }
}
