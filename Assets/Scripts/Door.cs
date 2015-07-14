using UnityEngine;
using System.Collections;

public class Door : Actor 
{
    private Door myDoor;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void Open(Door doorInstance1)
    {
        myDoor = doorInstance1;
        OnDestroy();
    }

    void OnDestroy()
    {
        Destroy(myDoor);
    }
}
