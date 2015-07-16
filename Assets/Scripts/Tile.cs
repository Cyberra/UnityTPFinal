using UnityEngine;
using System.Collections;

// Using list to store my objects on the scene.
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    // Player reference
    private Player myPlayer;

    // Assign my Prefabs inside Unity.
    public StarBlock sbPrefab;
    public GameObject switchPrefab;
    public GameObject doorPrefab;
    public EndDoor endDoorPrefab;
    public GameObject platformPrefab;
    public GameObject wall1Prefab;
    public GameObject wall2Prefab;
    public GameObject wall3Prefab;
    public GameObject stonePlatform1Prefab;
    public GameObject stonePlatform2Prefab;

    private bool isStarblock = false;

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

    // Bridge
    private string stoneBridge = "Tile65-13";

    // EndDoor
    private string endDoor = "Tile81-5";

    void Awake()
    {
        myPlayer = Player.FindObjectOfType<Player>();
    }

	// Need to use 'Start' in order to place the objects.
    void Start()
    {
        // Doors to unlock during the level.
        if (name == door1)
        {
            SpawnDoor();
        }
        if (name == door2)
        {
            SpawnDoor();
        }
        if (name == door3)
        {
            SpawnDoor();
        }
        if (name == door4)
        {
            SpawnDoor();
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
        
        // Switch Stone platforms
        if (name == stoneBridge)
        {
            SpawnStoneBridge();
        }

        // End door to finish the level.
        if (name == endDoor)
        {
            SpawnEndDoor();
        }
    }

    private void SpawnDoor()
    {
        GameObject door = (GameObject)Instantiate(doorPrefab);
        door.transform.position = this.transform.position;
        door.tag = "Door";
    }

    private void SpawnStarBlocks()
    {
        StarBlock sb = (StarBlock)Instantiate(sbPrefab);
        sb.transform.position = this.transform.position;
        sb.Destroyed += Empty;
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
        swBlock.tag = "Switch";
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

    private void SpawnStoneBridge()
    {
        GameObject bridge = (GameObject)Instantiate(stonePlatform2Prefab);
        bridge.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        Collider2D coll = GetComponent<Collider2D>();
        coll.enabled = false;
        bridge.tag = "StoneBridge";
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
        endDoor.tag = "EndDoor";
    }

    private void Empty(StarBlock sb)
    {
        isStarblock = false;
        sb.Destroyed -= Empty;

        GameObject[] switches = GameObject.FindGameObjectsWithTag("Switch");
        if (sb.transform.position == switches[0].transform.position)
        {
            CloseDoor(0);
        }
        else if (sb.transform.position == switches[1].transform.position)
        {
            CloseDoor(1);
        }
        else if (sb.transform.position == switches[2].transform.position)
        {
            CloseBridge(0);
        }
        else if (sb.transform.position == switches[3].transform.position)
        {
            CloseDoor(2);
        }
        else if (sb.transform.position == switches[4].transform.position)
        {
            CloseDoor(3);
        }
    }

    private void OpenBridge(int bridgeNumber)
    {
        GameObject[] bridgeRef = GameObject.FindGameObjectsWithTag("StoneBridge");
        bridgeRef[bridgeNumber].transform.position = new Vector3(bridgeRef[bridgeNumber].transform.position.x, bridgeRef[bridgeNumber].transform.position.y, 0);
        Collider2D coll = bridgeRef[bridgeNumber].GetComponent<Collider2D>();
        coll.enabled = true;
    }

    private void CloseBridge(int bridgeNumber)
    {
        GameObject[] bridgeRef = GameObject.FindGameObjectsWithTag("StoneBridge");
        bridgeRef[bridgeNumber].transform.position = new Vector3(bridgeRef[bridgeNumber].transform.position.x, bridgeRef[bridgeNumber].transform.position.y, 1);
        Collider2D coll = bridgeRef[bridgeNumber].GetComponent<Collider2D>();
        coll.enabled = false;
    }

    private void OpenDoor(int doorNumber)
    {
        // Set z position behind and disable the collider2D.
        GameObject[] doorRef = GameObject.FindGameObjectsWithTag("Door");
        doorRef[doorNumber].transform.position = new Vector3(doorRef[doorNumber].transform.position.x, doorRef[doorNumber].transform.position.y, 1);
        Collider2D coll = doorRef[doorNumber].GetComponent<Collider2D>();
        coll.enabled = false;
    }

    private void CloseDoor(int doorNumber)
    {
        // Set z position back and enable the collider2D.
        GameObject[] doorRef = GameObject.FindGameObjectsWithTag("Door");
        doorRef[doorNumber].transform.position = new Vector3(doorRef[doorNumber].transform.position.x, doorRef[doorNumber].transform.position.y, 0);
        Collider2D coll = doorRef[doorNumber].GetComponent<Collider2D>();
        coll.enabled = true;
    }

    void OnMouseDown()
    {
        if (isStarblock == false && myPlayer.inventoryStarBlocks > 0)
        {
            StarBlock starBlock = (StarBlock)Instantiate(sbPrefab);
            starBlock.transform.position = this.transform.position;
            starBlock.Destroyed += Empty;
            isStarblock = true;
            myPlayer.inventoryStarBlocks--;
        }
        
        if (name == switch1)
        {
            OpenDoor(0);
        }

        if (name == switch2)
        {
            OpenDoor(1);
        }

        if (name == switch3)
        {
            OpenBridge(0);
        }

        if (name == switch4)
        {
            OpenDoor(2);
        }

        if (name == switch5)
        {
            OpenDoor(3);
        }
    }
}