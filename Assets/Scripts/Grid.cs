using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour 
{
    public Camera cam;
	public GameObject plane;
	public int width;
	public int height;
	private float distanceX;
	private float distanceY;
	public float squareSize;
    
    public GameObject[,] grid = new GameObject[100, 100];


	void Awake ()
    {
		for (int i = 0; i < width; ++i) 
        {
			distanceX += squareSize;
			distanceY = 0;
			for (int j = 0; j < height; ++j)
            {
				distanceY += squareSize;
				GameObject gridPlane = (GameObject)Instantiate(plane);
				gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + distanceX, gridPlane.transform.position.y + distanceY);
				grid[i, j] = gridPlane;
			}
		}
	}
	
	// Use this for initialization
	void Start () 
    {
        cam.GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            
        }
	}

    void OnMouseDown()
    {
        Debug.Log("OH");
    }
}
