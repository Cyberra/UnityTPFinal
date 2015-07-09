using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour 
{
    public int width;
    public int height;
    private Tile[,] myGrid;
    public Grid grid;

	// Use this for initialization
	void Start () 
    {
        myGrid = new Tile[width, height];
        //for (int i = 0; i < width; ++i)
        //{
        //    for (int j = 0; j < height; ++j)
        //    {
        //        myGrid[i, j] = new Tile();
        //    }
        //}
        //myGrid = GetComponent<Tile[,]>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        
    }

    void OnMouseDown()
    {
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                if (myGrid[i, j])
                Debug.Log(myGrid[i, j]);
            }
        }
    }
}
