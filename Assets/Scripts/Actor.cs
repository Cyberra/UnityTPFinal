using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour 
{
    [HideInInspector]
    public Transform aTransform;

	// Use this for initialization
	void Awake () 
    {
        aTransform = transform;
	}
}
