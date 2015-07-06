using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public GameObject player = null;

	private Vector3 cameraOffSet = Vector3.zero;

	// Use this for initialization
	void Start () {
		cameraOffSet = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCamera ();
	}

	void UpdateCamera(){
		if (player != null) {
			transform.LookAt(player.transform);
		}
		
		transform.position = player.transform.position + cameraOffSet;
	}
}
