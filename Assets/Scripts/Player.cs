using UnityEngine;
using System.Timers;
using System.Collections;

public class Player : MonoBehaviour 
{
    // My references in my components.
    public Animator myAnim;
	public Rigidbody2D myBody;

    // Adjust the player movement.
	public float playerSpeed;
	public float jumpPower;

    // Keep public to communicate through scripts.
	public bool isJumping;
    private bool isLanding = false;

    // Animation variables.
    private int animChoice = 0;
    private float idleSpacingTime = 0;

	void Start () 
    {
		// Get the body of Kirby.
		myBody = GetComponent<Rigidbody2D>();
        // Get my animation sheet.
        myAnim = GetComponent<Animator>();
	}

	void FixedUpdate () 
    {
        float dt = Time.fixedDeltaTime;

        myAnimations(dt);
		myControls();
	}

    // Animations used for the player.
    void myAnimations(float dt)
    {
        idleSpacingTime += dt;

        if (idleSpacingTime >= 3f)
        {
            idleSpacingTime = 0;
            myAnim.SetFloat("IdleSpacing", 0);
        }

        // Timer to delay the idle state.
        myAnim.SetFloat("IdleSpacing", idleSpacingTime);

        

        if (myBody.velocity.y >= 0.1f && isJumping == true)
        {
            animChoice = 2;
        }
        else if (myBody.velocity.y <= 0.1f && myBody.velocity.y >= -0.1f && isJumping == true)
        {
            animChoice = 4;
        }
        else if (myBody.velocity.y < -0.1f && isJumping == true)
        {
            animChoice = 5;
            isLanding = true;
        }
        else if (isLanding == true && isJumping == false)
        {
            animChoice = 6;
            isLanding = false;
        }
        else if (isJumping == false)
        {
            if (myBody.velocity.x > 0.1f)
            {
                animChoice = 1;
                myBody.transform.localScale = new Vector3(1, 1, 1);
            }
            
            if (myBody.velocity.x < -0.1f)
            {
                animChoice = 1;
                myBody.transform.localScale = new Vector3(-1, 1, 1);
            }

            if (myBody.velocity.x < 0.1f && myBody.velocity.x > -0.1f)
            {
                animChoice = 0;
            }
        }

        myAnim.SetInteger("Choice", animChoice);

        //Debug.Log(myBody.velocity.x);
        Debug.Log(animChoice);
    }

	// Controls used by the player.
	void myControls() 
    {
		if (Input.GetKey (KeyCode.D) && myBody.velocity.x <= 2.0f)
        {
            if (myBody.velocity.x <= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
			//myBody.AddForce(new Vector2(playerSpeed, 0), ForceMode2D.Force);
            myBody.velocity = new Vector3(playerSpeed, myBody.velocity.y, 0);
		}

		if (Input.GetKey (KeyCode.A) && myBody.velocity.x >= -2.0f) 
        {
            if (myBody.velocity.x >= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
            //myBody.AddForce(new Vector2(-playerSpeed, 0), ForceMode2D.Force);
            myBody.velocity = new Vector3(-playerSpeed, myBody.velocity.y, 0);
		}

		if (Input.GetKey (KeyCode.Space) && isJumping == false) 
        {
			isJumping = true;
            myBody.velocity = new Vector3(myBody.velocity.x, jumpPower, 0);
		}
	}

	// On any collision detection, the player can't jump.
	void OnCollisionEnter2D(Collision2D coll) 
    {
		// Jumping conditions
		if (coll.gameObject.tag == "Ground") 
        {
			isJumping = false;
		}
	}
}
