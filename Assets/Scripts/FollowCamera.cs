using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
    // Add the player for the camera.
	public Player player;

    private float halfWidth;

    // My lerp strength.
    public float lerpStrength;

    void Awake()
    {
        halfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (player.transform.position.x >= halfWidth)
        {
            UpdateXAxis();
        }
        // Makes sure the camera doesn't look off screen.
        else if (player.transform.position.x < halfWidth)
        {
            transform.position = new Vector3(halfWidth, transform.position.y, transform.position.z);
        }

        if (player.transform.position.y <= halfWidth)
        {
            UpdateYAxis();
        }
        else if (player.transform.position.y > halfWidth)
        {
            transform.position = new Vector3(transform.position.x, halfWidth, transform.position.z);
        }


        //if (player.transform.position.x <= halfWidth)
        //{
        //    Debug.Log("Plus petit");
        //    transform.position = new Vector3(halfWidth, transform.position.y, transform.position.z);
        //}
        //else if (player.transform.position.x > halfWidth)
        //{
        //    Debug.Log("Plus grand");
		//    UpdateCamera ();
        //}
	}

    // Using a lerp to smooth the camera movement around with the player so it doesn't look glitchy.
	void UpdateCamera(){
        // Make sure the camera is looking at the existing player.
		if (player != null) 
        {
            transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y, 0));
		}

        // Apply lerps when jumping.
		if (player.isJumping) 
        {
            transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, transform.position.y, transform.position.z),
                                              new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z),
                                              lerpStrength);
		}

        // Makes a new lerp so the camera comes back smoothly.
		if (!player.isJumping) 
        {
            transform.position = Vector3.Lerp(new Vector3(player.transform.position.x, transform.position.y, transform.position.z),
                                              new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z),
                                              lerpStrength);
		}
	}

    void UpdateXAxis()
    {
        if (player != null)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, 0));
        }

        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                          new Vector3(player.transform.position.x, transform.position.y, transform.position.z),
                                          lerpStrength);
    }

    void UpdateYAxis()
    {
        if (player != null)
        {
            transform.LookAt(new Vector3(transform.position.x, player.transform.position.y, 0));
        }

        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                          new Vector3(transform.position.x, player.transform.position.y, transform.position.z),
                                          lerpStrength);
    }
}
