using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : ScriptableObject
{

    public float maxTime;
    public float curTime;

    // Start is called before the first frame update
    void Start()
    {
        curTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
