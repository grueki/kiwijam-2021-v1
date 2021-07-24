using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateTransitions : MonoBehaviour
{   
    public GameObject player;
    Rigidbody2D playerBody;
    SpriteRenderer playerSR;
    BoxCollider2D playerBC;

    //state sizes
    float liquidStateSizeX = 0.65f;
    float liquidStateSizeY = 0.55f;
    float solidStateSizeX = 1.45f;
    float solidStateSizeY = 1.5f;
    float gasStateSizeX = 1.5f;
    float gasStateSizeY = 0.6f;

    //state offsets
    float liquidOffsetX = 0f;
    float liquidOffsetY = -0.01f;
    float solidOffsetX = 0f;
    float solidOffsetY = 0f;
    float gasOffsetX = 0f;
    float gasOffsetY = -0.45f;

    //private int currentState; //order of states: Liquid(0), Solid(1), SolidAngry(2), Gas(3)
    public List<Sprite> playerStates = new List<Sprite>(); 

    private Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        //get components
        playerBody = player.GetComponent<Rigidbody2D>();
        playerSR = player.GetComponent<SpriteRenderer>();
        playerBC = player.GetComponent<BoxCollider2D>();

        //initialise the player state to first state 0 (liquid)
        playerSR.sprite = playerStates[0];
        playerBC.size = new Vector2(liquidStateSizeX, liquidStateSizeY); //set collider size
        playerBC.offset = new Vector2(liquidOffsetX, liquidOffsetY); //set collider offset
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeSpriteDown();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeSpriteUp();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //get and store the initial position of the touch
            if (touch.phase == TouchPhase.Began)
            {
                initialPosition = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                //get the displace of the touch
                var displacement = touch.position - initialPosition;

                //check if the displacement is signficant enough to be a swipe
                if (Mathf.Abs(displacement.x) > 5f || Mathf.Abs(displacement.y) > 5f)
                {
                    //get the direction of the touch swipe
                    //get the signed x direction, if (displacement.x >= 0) then 1 else -1
                    var signedDirection = Mathf.Sign(displacement.y);

                    //up swipe, update movement
                    if (signedDirection == 1)
                    {
                        //Debug.Log("swiped up");
                        changeSpriteUp();
                    }

                    //down swipe, update movement
                    if (signedDirection == -1)
                    {
                        //Debug.Log("swipe down");
                        changeSpriteDown();
                    }
                }
            }
        }
    }

    //function to change player state
    void changeSpriteUp()
    {   
        if (playerSR.sprite == playerStates[0]) //if player is liquid
        {
            playerSR.sprite = playerStates[1]; //change to solid
            playerBC.size = new Vector2(solidStateSizeX, solidStateSizeY); //change collider size
            playerBC.offset = new Vector2(solidOffsetX, solidOffsetY); //change collider offset
        }
        else if (playerSR.sprite == playerStates[1]) //if player is solid
        {
            playerSR.sprite = playerStates[3]; //change to gas
            playerBC.size = new Vector2(gasStateSizeX, gasStateSizeY); //change collider size
            playerBC.offset = new Vector2(gasOffsetX, gasOffsetY); //change collider offset
            playerBody.gravityScale *= -1; //flip gravity
        }
    }

    void changeSpriteDown()
    {
        if (playerSR.sprite == playerStates[3]) //if player is gas
        {
            playerSR.sprite = playerStates[1]; //change to solid
            playerBC.size = new Vector2(solidStateSizeX, solidStateSizeY); //change collider size
            playerBC.offset = new Vector2(solidOffsetX, solidOffsetY); //change collider offset
            playerBody.gravityScale *= -1; //flip gravity
        }
        else if (playerSR.sprite == playerStates[1]) //if player is solid
        {
            playerSR.sprite = playerStates[0]; //change to liquid
            playerBC.size = new Vector2(liquidStateSizeX, liquidStateSizeY); //change collider size
            playerBC.offset = new Vector2(liquidOffsetX, liquidOffsetY); //change collider offset
        }
    }

}
