using UnityEngine;
using System.Timers;
using System.Collections;

public class Player : MonoBehaviour 
{
    // My references in my components.
    [HideInInspector]
    public Animator myAnim;
    [HideInInspector]
	public Rigidbody2D myBody;
    [HideInInspector]
    public int inventoryStarBlocks = 0;

    // Adjust the player movement.
	public float playerSpeed;
	public float jumpPower;
    public float playerRange;

    // Keep public to communicate through scripts.
    [HideInInspector]
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

    private void UpdateTimers()
    {
        // Timer for the idle state.
        if (idleSpacingTime >= 3f)
        {
            idleSpacingTime = 0;
            myAnim.SetFloat("IdleSpacing", 0);
        }

        // Timer to reset the roll state when stuck with it on the ground.
        if (rollReset >= 1.0f)
        {
            rollReset = 0;
        }

        // Set the variables inside the Animator.
        myAnim.SetFloat("IdleSpacing", idleSpacingTime);
        myAnim.SetFloat("RollReset", rollReset);
    }

    // Animations used for the player.
    void myAnimations(float dt)
    {
        // Timer to delay the idle state.
        idleSpacingTime += dt;
        rollReset += dt;
        
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

    private void MoveRight()
    {
        // Use the D key or the right arrow.
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && myBody.velocity.x <= 2.0f)
        {
            // Sets the correct velocity.
            if (myBody.velocity.x <= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
            myBody.AddForce(new Vector2(playerSpeed, 0), ForceMode2D.Force);
        }
    }

    private void MoveLeft()
    {
        // Use the A key or the left arrow.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && myBody.velocity.x >= -2.0f)
        {
            // Sets the correct velocity.
            if (myBody.velocity.x >= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
            myBody.AddForce(new Vector2(-playerSpeed, 0), ForceMode2D.Force);
        }
    }

    private void Jump()
    {
        // Jump by pressing space bar.
        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            myBody.velocity = new Vector3(myBody.velocity.x, jumpPower, 0);
        }
    }

	// Controls used by the player.
	void myControls() 
    {
        MoveRight();
        MoveLeft();
        Jump();
	}

	// On any collision detection, the player can't jump.
	void OnCollisionEnter2D(Collision2D coll) 
    {
		// Jumping conditions
		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "StoneBridge") 
        {
			isJumping = false;
		}

        // If the player reaches the ending door.
        if (coll.gameObject.tag == "EndDoor")
        {
            Application.LoadLevel("EndScreen");
        }
	}
}
