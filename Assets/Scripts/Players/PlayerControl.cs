using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour
{

    //player1?
    public enum Players { player1, player2 };
    public Players playerType;

    public float speed = 0.5f;
    public float jumpTime = 1;
    public Scroller scroller;

    float jumpTimeBuffered;
    bool rightSide;

    Vector3 lerpPos;
    float lerpStep = 0;

    // Use this for initialization
    void Start()
    {
        jumpTimeBuffered = jumpTime;
        jumpTime = 0;

        lerpPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       

        lerpStep += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(transform.position, lerpPos, lerpStep);

        //if player 1 jumps
        if (Input.GetButtonDown("Switch1") && playerType == Players.player1)
        {
            //check to which side to switch
            if (rightSide)
            {
                lerpPos = new Vector3(-6, transform.position.y, 0);
            }
            else
            {
                lerpPos = new Vector3(-2, transform.position.y, 0);
            }
            //invert right side
            rightSide = !rightSide;
            lerpStep = 0;
        }
        //if player 2 jumps
        if (Input.GetButtonDown("Switch2") && playerType == Players.player2)
        {
            //check to which side to switch
            if (rightSide)
            {
                lerpPos = new Vector3(2, transform.position.y, 0);
            }
            else
            {
                lerpPos = new Vector3(6, transform.position.y, 0);
            }
            //invert right side
            rightSide = !rightSide;
            lerpStep = 0;
        }

        if (Input.GetButtonDown("Jump1") && playerType == Players.player1 && jumpTime == 0)
        {
            Jump();
        }
        else if (Input.GetButtonDown("Jump2") && playerType == Players.player2 && jumpTime == 0)
        {
            Jump();
        }
        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }
        else if (jumpTime < 0)
        {
            lerpPos.y = -2.5f;
            jumpTime = 0;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Animator>().SetBool("Jumping", false);
        }

        //adjust animation speed - dependent on scroll speed of Scroller
        gameObject.GetComponent<Animator>().speed = scroller.scrollSpeed / 4 + 0.3f;

    }

    void Jump()
    {
        lerpPos.y = -2;
        jumpTime = jumpTimeBuffered;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("Jumping", true);
    }
}
