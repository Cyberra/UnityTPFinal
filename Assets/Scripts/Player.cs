using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D myBody;

	public float playerSpeed;
	public float jumpPower;

	public bool isJumping;
	public Collider2D ground;

	void Start () {
		// Get the body of Kirby
		myBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		myControls ();
	}

	// Controls used by the player.
	void myControls() {
		if (Input.GetKey (KeyCode.D) && myBody.velocity.x <= 2.0f){
			//transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
			myBody.AddForce(new Vector2(playerSpeed, 0), ForceMode2D.Force);
			// Check for AddForce with david.
		}

		if (Input.GetKey (KeyCode.A) && myBody.velocity.x >= -2.0f) {
			myBody.AddForce(new Vector2(-playerSpeed, 0), ForceMode2D.Force);
		}

		if (Input.GetKey (KeyCode.Space) && isJumping == false) {
			isJumping = true;
			myBody.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
		}

		// Set boolean so the player can't jump while in the air.
		if (myBody.IsTouching (ground) == true) {
			isJumping = false;
		}
	}

	// On any collision detection, the player can't jump.
	void OnCollisionStay2D(Collision2D coll) {
		// Jumping conditions
		//if (coll.gameObject.tag == "Ground") {
		//	isJumping = false;
		//}
	}
}
