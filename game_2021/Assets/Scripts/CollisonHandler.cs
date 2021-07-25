using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonHandler : MonoBehaviour
{
    public Sprite angryMode;
    public List<Sprite> changes = new List<Sprite>(); //dead enemy -> 0, open chest -> 1
    public float thrust;

    private Rigidbody2D rb2D;

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
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (GetComponent<SpriteRenderer>().sprite == angryMode)
            {
                killEnemy(collision.gameObject);
            }
            else
            {
                endGame();
            }
        }

        else if (collision.gameObject.CompareTag("chest"))
        {
            if (GetComponent<SpriteRenderer>().sprite == angryMode)
            {
                breakChest(collision.gameObject);
            }
        }
    }

    //end game due to collision with enemy or out of screen
    void endGame()
    {

    }

    void killEnemy(GameObject enemy)
    {
        //change enemy sprite to death sprite
        enemy.GetComponent<SpriteRenderer>().sprite = changes[0];

        //give the enemy a rigid body, add force to the enemy and make them fly back
        rb2D = enemy.GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.right * thrust);
        rb2D.AddForce(transform.up * thrust/2f);

        //destory enemy object
        GetComponentInParent<ObstacleGeneration>().activeObstacles.RemoveAt(0);
        Destroy(enemy, 0.7f);

    }

    void breakChest(GameObject chest)
    {
        //change chest sprite to open chest sprite
        chest.GetComponent<SpriteRenderer>().sprite = changes[1];

        //add force to the chest to make it fly up 
        rb2D = chest.GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.right * thrust/2f);
        rb2D.AddForce(transform.up * thrust);

        //destory the chest object
        GetComponentInParent<ObstacleGeneration>().activeObstacles.RemoveAt(0);
        Destroy(chest, 0.5f);
    }
}