using UnityEngine;
using System.Collections;

// Using list to store my objects on the scene.
using System.Collections.Generic;

public class Tile : Actor
{
    // Assign my Prefabs inside Unity.
    public StarBlock sbPrefab;
    public GameObject switchPrefab;
    public Door doorPrefab;
    public EndDoor endDoorPrefab;
    public GameObject platformPrefab;
    public GameObject wall1Prefab;
    public GameObject wall2Prefab;
    public GameObject wall3Prefab;
    public GameObject stonePlatform1Prefab;
    public GameObject stonePlatform2Prefab;

    private bool isStarblock = false;

    Door doorInstance1;
    Door doorInstance2;
    Door doorInstance3;
    Door doorInstance4;

    // Doors
    private string door1 = "Tile20-9";
    private string door2 = "Tile40-7";
    private string door3 = "Tile78-5";
    private string door4 = "Tile79-5";
    
    // StarBlocks
    private string starblock1 = "Tile9-10";
    private string starblock2 = "Tile24-16";
    private string starblock3 = "Tile52-16";
    private string starblock4 = "Tile72-16";

    //Platforms
    private string platform1 = "Tile24-13";
    private string platform2 = "Tile28-11";
    private string platform3 = "Tile24-10";
    private string platform4 = "Tile47-12";
    private string platform5 = "Tile43-11";
    private string platform6 = "Tile47-9";
    private string platform7 = "Tile43-8";

    // Switches
    private string switch1 = "Tile14-10";
    private string switch2 = "Tile34-9";
    private string switch3 = "Tile58-16";
    private string switch4 = "Tile74-6";
    private string switch5 = "Tile75-6";

    // Walls
    private string wall1 = "Tile20-14";
    private string wall2 = "Tile40-13";
    private string wall3 = "Tile78-12";
    private string wall4 = "Tile79-12";

    // Stone platforms
    private string stonePlatform1 = "Tile55-13";
    private string stonePlatform2 = "Tile72-13";

    // EndDoor
    private string endDoor = "Tile81-5";

	// Need to use 'Start' in order to place the objects.
    void Start()
    {
        // Doors to unlock during the level.
        if (name == door1)
        {
            doorInstance1 = (Door)Instantiate(doorPrefab);
            doorInstance1.transform.position = this.transform.position;
        }
        if (name == door2)
        {
            doorInstance2 = (Door)Instantiate(doorPrefab);
            doorInstance2.transform.position = this.transform.position;
        }
        if (name == door3)
        {
            doorInstance3 = (Door)Instantiate(doorPrefab);
            doorInstance3.transform.position = this.transform.position;
        }
        if (name == door4)
        {
            doorInstance4 = (Door)Instantiate(doorPrefab);
            doorInstance4.transform.position = this.transform.position;
        }

        // Star blocks.
        if (name == starblock1)
        {
            SpawnStarBlocks();
        }
        if (name == starblock2)
        {
            SpawnStarBlocks();
        }
        if (name == starblock3)
        {
            SpawnStarBlocks();
        }
        if (name == starblock4)
        {
            SpawnStarBlocks();
        }

        // Platforms
        if (name == platform1)
        {
            SpawnPlatforms();
        }
        if (name == platform2)
        {
            SpawnPlatforms();
        }
        if (name == platform3)
        {
            SpawnPlatforms();
        }
        if (name == platform4)
        {
            SpawnPlatforms();
        }
        if (name == platform5)
        {
            SpawnPlatforms();
        }
        if (name == platform6)
        {
            SpawnPlatforms();
        }
        if (name == platform7)
        {
            SpawnPlatforms();
        }

        // Switch blocks.
        if (name == switch1)
        {
            SpawnSwitch();
        }
        if (name == switch2)
        {
            SpawnSwitch();
        }
        if (name == switch3)
        {
            SpawnSwitch();
        }
        if (name == switch4)
        {
            SpawnSwitch();
        }
        if (name == switch5)
        {
            SpawnSwitch();
        }

        // Walls
        if (name == wall1)
        {
            SpawnWall1();
        }
        if (name == wall2)
        {
            SpawnWall2();
        }
        if (name == wall3)
        {
            SpawnWall3();
        }
        if (name == wall4)
        {
            SpawnWall3();
        }

        // StonePlaforms
        if (name == stonePlatform1)
        {
            SpawnStonePlatform1();
        }
        if (name == stonePlatform2)
        {
            SpawnStonePlatform2();
        }

        // End door to finish the level.
        if (name == endDoor)
        {
            SpawnEndDoor();
        }
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
        EndDoor endDoor = (EndDoor)Instantiate(endDoorPrefab);
        endDoor.transform.position = this.transform.position;
    }

    private void Empty(StarBlock sb)
    {
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
        }

        
        Debug.Log(name);
        if (name == switch1 && doorInstance1 != null)
        {
            doorInstance1.transform.position = new Vector3(0, 0, 0);
        }
    }
}