using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    // Assign my Prefabs inside Unity.
    public StarBlock sbPrefab;
    public GameObject switchPrefab;
    public GameObject doorPrefab;
    public GameObject endDoorPrefab;
    public GameObject platformPrefab;
    public GameObject wall1Prefab;
    public GameObject wall2Prefab;
    public GameObject wall3Prefab;
    public GameObject stonePlatform1Prefab;
    public GameObject stonePlatform2Prefab;

    private bool isStarblock = false;

	// Need to use 'Start' in order to place the objects.
    void Start()
    {
        // Doors to unlock during the level.
        if (name == "Tile20-9")
        {
            SpawnDoor();
        }
        if (name == "Tile40-7")
        {
            SpawnDoor();
        }
        if (name == "Tile78-5")
        {
            SpawnDoor();
        }
        if (name == "Tile79-5")
        {
            SpawnDoor();
        }

        // Star blocks.
        if (name == "Tile9-10")
        {
            SpawnStarBlocks();
        }
        if (name == "Tile24-16")
        {
            SpawnStarBlocks();
        }
        if (name == "Tile52-16")
        {
            SpawnStarBlocks();
        }
        if (name == "Tile72-16")
        {
            SpawnStarBlocks();
        }

        // Platforms
        if (name == "Tile24-13")
        {
            SpawnPlatforms();
        }
        if (name == "Tile28-11")
        {
            SpawnPlatforms();
        }
        if (name == "Tile24-10")
        {
            SpawnPlatforms();
        }
        if (name == "Tile47-12")
        {
            SpawnPlatforms();
        }
        if (name == "Tile43-11")
        {
            SpawnPlatforms();
        }
        if (name == "Tile47-9")
        {
            SpawnPlatforms();
        }
        if (name == "Tile43-8")
        {
            SpawnPlatforms();
        }

        // Switch blocks.
        if (name == "Tile14-10")
        {
            SpawnSwitch();
        }
        if (name == "Tile34-9")
        {
            SpawnSwitch();
        }
        if (name == "Tile58-16")
        {
            SpawnSwitch();
        }
        if (name == "Tile74-6")
        {
            SpawnSwitch();
        }
        if (name == "Tile75-6")
        {
            SpawnSwitch();
        }

        // Walls
        if (name == "Tile20-14")
        {
            SpawnWall1();
        }
        if (name == "Tile40-13")
        {
            SpawnWall2();
        }
        if (name == "Tile78-12")
        {
            SpawnWall3();
        }
        if (name == "Tile79-12")
        {
            SpawnWall3();
        }

        // StonePlaforms
        if (name == "Tile55-13")
        {
            SpawnStonePlatform1();
        }
        if (name == "Tile72-13")
        {
            SpawnStonePlatform2();
        }

        // End door to finish the level.
        if (name == "Tile81-5")
        {
            SpawnEndDoor();
        }
    }

    private void SpawnDoor()
    {
        GameObject door = (GameObject)Instantiate(doorPrefab);
        door.transform.position = this.transform.position;
    }

    private void SpawnStarBlocks()
    {
        StarBlock sb = (StarBlock)Instantiate(sbPrefab);
        sb.transform.position = this.transform.position;
    }

    private void SpawnPlatforms()
    {
        GameObject platform = (GameObject)Instantiate(platformPrefab);
        platform.transform.position = this.transform.position;
    }

    private void SpawnSwitch()
    {
        GameObject swBlock = (GameObject)Instantiate(switchPrefab);
        swBlock.transform.position = this.transform.position;
    }

    private void SpawnStonePlatform1()
    {
        GameObject stonePlatform = (GameObject)Instantiate(stonePlatform1Prefab);
        stonePlatform.transform.position = this.transform.position;
    }

    private void SpawnStonePlatform2()
    {
        GameObject stonePlatform = (GameObject)Instantiate(stonePlatform2Prefab);
        stonePlatform.transform.position = this.transform.position;
    }

    private void SpawnWall1()
    {
        GameObject wall = (GameObject)Instantiate(wall1Prefab);
        wall.transform.position = this.transform.position;
    }

    private void SpawnWall2()
    {
        GameObject wall = (GameObject)Instantiate(wall2Prefab);
        wall.transform.position = this.transform.position;
    }

    private void SpawnWall3()
    {
        GameObject wall = (GameObject)Instantiate(wall3Prefab);
        wall.transform.position = this.transform.position;
    }

    private void SpawnEndDoor()
    {
        GameObject endDoor = (GameObject)Instantiate(endDoorPrefab);
        endDoor.transform.position = this.transform.position;
    }

    private void Empty(StarBlock sb)
    {
        Debug.Log("HEY");
        isStarblock = false;
        sb.Destroyed -= Empty;
    }

    void OnMouseDown()
    {
        if (isStarblock == false)
        {
            StarBlock starBlock = (StarBlock)Instantiate(sbPrefab);
            starBlock.transform.position = this.transform.position;
            starBlock.Destroyed += Empty;
            isStarblock = true;
            Debug.Log(gameObject.name);
        }
    }
}
