using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : Actor 
{
    public Tile plane;
	public int width;
	public int height;
	private float distanceX;
	private float distanceY;
	public float squareSize;

    public Tile[,] grid = new Tile[100, 100];

	void Awake()
    {
		for (int i = 0; i < width; ++i) 
        {
			distanceX += squareSize;
			distanceY = 0;
			for (int j = 0; j < height; ++j)
            {
				distanceY += squareSize;
                Tile gridPlane = (Tile)Instantiate(plane);
                gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + distanceX, gridPlane.transform.position.y + distanceY);
				grid[i, j] = gridPlane;
                gridPlane.gameObject.name = "Tile" + i + "-" + j;
			}
		}
	}
}
