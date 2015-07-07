using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject plane;
	public int width;
	public int height;
	private float distanceX;
	private float distanceY;
	public float squareSize;

	private GameObject [,] grid = new GameObject[10, 10];


	void Awake () {
		for (int i = 0; i < width; ++i) {
			distanceX += squareSize;
			distanceY = 0;
			for (int j = 0; j < height; ++j){
				distanceY += squareSize;
				GameObject gridPlane = (GameObject)Instantiate(plane);
				gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + distanceX, gridPlane.transform.position.y + distanceY);
				grid[i, j] = gridPlane;
			}
		}
	}
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
	}
}
