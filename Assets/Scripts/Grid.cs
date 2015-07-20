using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour 
{
    // Plane used for a tile space.
    public Tile plane;

    // Public size of the grid.
	public int width;
	public int height;

    // Floats used inside the for loops to create a grid.
	private float distanceX;
	private float distanceY;

    // The size of the tiles used.
	public float squareSize;

    // Grid used to place items inside the level properly.
    public Tile[,] grid = new Tile[100, 100];

	void Awake()
    {
        InitGrid();
	}

    // With the public width/height, the player can freely adjust the size of the grid used in the level.
    private void InitGrid()
    {
        // Standalone version for windows. CONSTANTE DE COMPILATION
        #if UNITY_STANDALONE_WIN
        for (int i = 0; i < width; ++i)
        {
            // Change the x coordinate for the next tile.
            distanceX += squareSize;
            distanceY = 0;
            for (int j = 0; j < height; ++j)
            {
                // Change the y coodinate for the next tile.
                distanceY += squareSize;
                // Instantiate the plane.
                Tile gridPlane = (Tile)Instantiate(plane);
                gridPlane.transform.position = new Vector3(gridPlane.transform.position.x + distanceX, gridPlane.transform.position.y + distanceY);
                grid[i, j] = gridPlane;
                // Give it the correct name in order to get access to it easily.
                gridPlane.gameObject.name = "Tile" + i + "-" + j;
            }
        }
        #endif
    }
}
