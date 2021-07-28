using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Vector2 initialPosition;

    Rigidbody2D m_rigidbody;
    public float m_jumpForce;
    private bool m_grounded;

    private float angryTime = 0.75f;

    //audio
    private AudioSource fromPlayerPC;
    public AudioClip goAngry;

    //order of states: Liquid(0), Solid(1), Gas(2)
    public List<Sprite> playerStates = new List<Sprite>();

    void Start()
    {
        fromPlayerPC = GetComponent<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_grounded = false;
    }

    void Update()
    {   
        if(transform.position.x < 0.25f)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }

        //timer for angry state change
        if (GetComponent<SpriteRenderer>().sprite == playerStates[2])
        {
            angryTime -= Time.deltaTime;
            if (angryTime < 0f)
            {
                //change player state back to non-angry ice and reset angry timer
                GetComponent<SpriteRenderer>().sprite = playerStates[1];
                angryTime = 0.75f;
            }
        }
        
        //keyboard controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpriteRenderer currentState = GetComponent<SpriteRenderer>();
            if (currentState.sprite == playerStates[1]) //if the player is in ice state then go angry!
            {
                fromPlayerPC.PlayOneShot(goAngry);
                currentState.sprite = playerStates[2];
            }
        }

        //mobile controls
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
                if (Mathf.Abs(displacement.x) < 2f || Mathf.Abs(displacement.y) < 2f)
                {
                    SpriteRenderer currentState = GetComponent<SpriteRenderer>();
                    if (currentState.sprite == playerStates[1]) //if the player is in ice state then go angry!
                    {
                        fromPlayerPC.PlayOneShot(goAngry);
                        currentState.sprite = playerStates[2];
                    }
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            m_grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            m_grounded = false;
        }
    }
}
