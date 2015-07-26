using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
    // Add the player for the camera.
	public Player player;

    // Choose to adjust the height of the camera following the player.
	public float cameraHeight;

    private float halfWidth;

    void Awake()
    {
        halfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (transform.position.x < halfWidth)
        {
            transform.position = new Vector3(halfWidth, transform.position.y, transform.position.z);
        }
        else if (player.transform.position.x >= halfWidth)
        {
		    UpdateCamera ();
        }
	}

    // Using a lerp to smooth the camera movement around with the player so it doesn't look glitchy.
	void UpdateCamera(){
        // Make sure the camera is looking at the existing player.
		if (player != null) 
        {
            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + cameraHeight, 0));
		}

        // Apply lerps when jumping.
		if (player.isJumping) 
        {
            transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), 0.3f);
		}

        // Makes a new lerp so the camera comes back smoothly.
		if (!player.isJumping) 
        {
            transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, transform.position.y, transform.position.z), new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), 0.3f);
		}
	}
}
