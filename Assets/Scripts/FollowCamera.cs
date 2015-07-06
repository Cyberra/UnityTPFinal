using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject player = null;

	private Vector3 cameraOffSet = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
		cameraOffSet = transform.position - player.transform.position;
		transform.Translate( new Vector3(0, 0, -5));
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCamera ();
	}

	void UpdateCamera(){
		if (player != null) {
			transform.LookAt(new Vector3(player.transform.position.x, 0, 0));
		}
		
		//transform.Translate(new Vector3(player.transform.position.x, 0, 0));

		transform.position = player.transform.position + cameraOffSet;
	}
}
