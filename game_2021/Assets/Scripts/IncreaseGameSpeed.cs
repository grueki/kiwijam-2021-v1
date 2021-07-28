using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGameSpeed : MonoBehaviour
{
    public float gameSpeed;
    private float time;
    private float incrementTimer;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        incrementTimer = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= incrementTimer)
        {
            gameSpeed += 0.0005f;
        }
    }
}
