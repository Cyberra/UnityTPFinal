using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
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
            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + cameraHeight, 0));
		}

		if (player.isJumping) 
        {
            transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), 0.3f);
		}

		if (!player.isJumping) 
        {
            transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), 0.3f);
		}
	}
}
