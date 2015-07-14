using UnityEngine;
using System.Collections;

public class FollowCamera : Actor 
{

	public Player player;

	public float cameraHeight;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
		UpdateCamera ();
	}

	void UpdateCamera(){
		if (player != null) 
        {
            aTransform.LookAt(new Vector3(player.aTransform.position.x, player.aTransform.position.y + cameraHeight, 0));
		}

		if (player.isJumping) 
        {
            aTransform.position = Vector3.Lerp(new Vector3(player.aTransform.position.x, aTransform.position.y, aTransform.position.z), new Vector3(player.aTransform.position.x, player.aTransform.position.y, aTransform.position.z), 0.3f);
		}

		if (!player.isJumping) 
        {
            aTransform.position = Vector3.Lerp(new Vector3(player.aTransform.position.x, aTransform.position.y, aTransform.position.z), new Vector3(player.aTransform.position.x, player.aTransform.position.y, aTransform.position.z), 0.3f);
		}
	}
}
