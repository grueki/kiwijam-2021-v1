using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //delete an object if it has passed the player and is off screen
        Destroy(collision.gameObject);
    }
}

