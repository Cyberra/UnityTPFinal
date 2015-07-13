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
    private float rollReset = 0;

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
        // Hold the player on the desired rotation.
        myBody.transform.localRotation = new Quaternion(0, 0, 0, 0);

        // Timer to delay the idle state.
        idleSpacingTime += dt;
        rollReset += dt;
        if (idleSpacingTime >= 3f)
        {
            idleSpacingTime = 0;
            myAnim.SetFloat("IdleSpacing", 0);
        }
        if (rollReset >= 1.0f)
        {
            rollReset = 0;
        }
        myAnim.SetFloat("IdleSpacing", idleSpacingTime);
        myAnim.SetFloat("RollReset", rollReset);
        
        // Play the correct animation depending on the playing condition.
        // animChoice represents the variable inside the state machine for the animation inside Unity.
        if (myBody.velocity.y >= 0.1f && isJumping == true)
        {
            // JumpStart
            animChoice = 2;
        }
        else if (myBody.velocity.y <= 0.1f && myBody.velocity.y >= -0.1f && isJumping == true)
        {
            // JumpPeak
            rollReset = 0;
            animChoice = 4;
            // Can't roll infinitely if you jump at the exact same height of the jump power.
            if (rollReset >= 0.8f)
            {
                animChoice = 0;
            }
        }
        else if (myBody.velocity.y < -0.1f && isJumping == true)
        {
            // JumpFall
            animChoice = 5;
            // Update the landing variable so the player can fall infinitely until he touches the ground.
            isLanding = true;
        }
        else if (isLanding == true && isJumping == false)
        {
            // JumpLand
            animChoice = 6;
            // Reset my variable.
            isLanding = false;
        }
        else if (isJumping == false)
        {
            // Move to the right.
            if (myBody.velocity.x > 0.1f && animChoice != 1)
            {
                animChoice = 1;
                myBody.transform.localScale = new Vector3(1, 1, 1);
            }
            // Check if the player is running.
            else if (myBody.velocity.x > 0.5f && animChoice == 1)
            {
                animChoice = 3;
            }
            
            // Move to the left.
            if (myBody.velocity.x < -0.1f && animChoice != 1)
            {
                animChoice = 1;
                myBody.transform.localScale = new Vector3(-1, 1, 1);
            }
            // Check if the player is running.
            else if (myBody.velocity.x < -0.5f && animChoice == 1)
            {
                animChoice = 3;
            }

            // Idle state.
            if (myBody.velocity.x < 0.5f && myBody.velocity.x > -0.5f)
            {
                animChoice = 0;
            }
        }

        // Set my animation for the state machine.
        myAnim.SetInteger("Choice", animChoice);
    }

	// Controls used by the player.
	void myControls() 
    {
        // Move right
		if (Input.GetKey (KeyCode.D) && myBody.velocity.x <= 2.0f)
        {
            if (myBody.velocity.x <= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
			myBody.AddForce(new Vector2(playerSpeed, 0), ForceMode2D.Force);
            //myBody.velocity = new Vector3(playerSpeed, myBody.velocity.y, 0);
		}

        // Move left
		if (Input.GetKey (KeyCode.A) && myBody.velocity.x >= -2.0f) 
        {
            if (myBody.velocity.x >= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
            myBody.AddForce(new Vector2(-playerSpeed, 0), ForceMode2D.Force);
            //myBody.velocity = new Vector3(-playerSpeed, myBody.velocity.y, 0);
		}

        // Jump
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
