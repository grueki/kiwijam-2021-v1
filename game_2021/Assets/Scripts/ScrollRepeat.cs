using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRepeat : MonoBehaviour
{
    private float length;

    private float levelSpeed; // TODO: make private and inherit from GameController

    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        levelSpeed = GetComponentInParent<IncreaseGameSpeed>().gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += -Mathf.Abs(levelSpeed * Time.deltaTime); // Abs handles accidental negative speeds. Edit if reverse speeds become necessary
        
        if(pos.x < -1.5f * length) pos.x += 3f * length;

        
        transform.position = pos;
    }

}
