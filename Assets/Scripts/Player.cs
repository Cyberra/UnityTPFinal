using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D myBody;
	private float playerSpeed = 1.0f;
	private const float playerMaxSpeed = 5.0f;
	private bool isMoving;


	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		myControls ();
	}

	void myControls() {
		Debug.Log (Input.GetAxis("Horizontal"));

		if (Input.GetKey("d")){
			transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
		}
		if (Input.GetKey("a")) {
			transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime);
		}
	}
}
