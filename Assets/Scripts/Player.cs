using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D myBody;

	public float playerSpeed;
	public float jumpPower; 

	private bool isJumping;


	void Start () {
		// Get the body of Kirby
		myBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		myControls ();
	}

	// Controls used by the player.
	void myControls() {
		if (Input.GetKey(KeyCode.D)){
			transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
			// Check for AddForce with david.
		}

		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
		}
		// Set boolean so the player can't jump while in the air.
		isJumping = true;
	}

	// On any collision detection, the player can't jump.
	void OnCollisionStay2D(Collision2D coll) {
		isJumping = false;
	}
}
