using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public Rigidbody2D myBody;

	public float playerSpeed;
	public float jumpPower;

	public bool isJumping;
	public Collider2D ground;
    public Collider2D ground1;

	void Start () 
    {
		// Get the body of Kirby
		myBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () 
    {
		myControls ();
	}

	// Controls used by the player.
	void myControls() {
		if (Input.GetKey (KeyCode.D) && myBody.velocity.x <= 2.0f)
        {
            if (myBody.velocity.x <= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
			myBody.AddForce(new Vector2(playerSpeed, 0), ForceMode2D.Force);
		}

		if (Input.GetKey (KeyCode.A) && myBody.velocity.x >= -2.0f) 
        {
            if (myBody.velocity.x >= 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
            }
			myBody.AddForce(new Vector2(-playerSpeed, 0), ForceMode2D.Force);
		}

		if (Input.GetKey (KeyCode.Space) && isJumping == false) 
        {
			isJumping = true;
            myBody.velocity = new Vector3(myBody.velocity.x, jumpPower, 0);
		}

		// Set boolean so the player can't jump while in the air.
		if (myBody.IsTouching (ground) == true || myBody.IsTouching(ground1) == true) 
        {
			isJumping = false;
		}
        Debug.Log(myBody.velocity);
	}

	// On any collision detection, the player can't jump.
	void OnCollisionStay2D(Collision2D coll) {
		// Jumping conditions
		//if (coll.gameObject.tag == "Ground") {
		//	isJumping = false;
		//}
	}
}
