﻿using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Player player;

	public float cameraHeight;
	private Vector3 cameraOffSet = new Vector3(0, 10, 0);

	// Use this for initialization
	void Start () {
		cameraOffSet = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UpdateCamera ();
	}

	void UpdateCamera(){
		if (player != null) {
			transform.LookAt (new Vector3 (player.transform.position.x, player.transform.position.y + cameraHeight, 0));
		}

		if (player.isJumping) {
			// TODO LERP // temp transform
			Debug.Log("ASSET STORE");
		} 
		if (!player.isJumping) {
			transform.position = player.transform.position + cameraOffSet;
		}
	}
}
