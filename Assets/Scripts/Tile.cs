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
    public GameObject endDoorPrefab;
    public GameObject platformPrefab;
    public GameObject wall1Prefab;
    public GameObject wall2Prefab;
    public GameObject wall3Prefab;
    public GameObject stonePlatform1Prefab;
    public GameObject stonePlatform2Prefab;

    // Set tiles emptied.
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
    private string platform4 = "Tile47-13";
    private string platform5 = "Tile43-11";
    private string platform6 = "Tile47-9";
    private string platform7 = "Tile43-7";

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
        // Set my reference.
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

    // Create doors with right tag.
    private void SpawnDoor()
    {
        GameObject door = (GameObject)Instantiate(doorPrefab);
        door.transform.position = this.transform.position;
        door.tag = "Door";
    }

    // Create a star block and listen to the event.
    private void SpawnStarBlocks()
    {
        StarBlock sb = (StarBlock)Instantiate(sbPrefab);
        sb.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.01f);
        sb.Destroyed += Empty;
    }

    // Spawn the star platforms.
    private void SpawnPlatforms()
    {
        GameObject platform = (GameObject)Instantiate(platformPrefab);
        platform.transform.position = this.transform.position;
    }

    // Spawn my switched inside the level.
    private void SpawnSwitch()
    {
        GameObject swBlock = (GameObject)Instantiate(switchPrefab);
        swBlock.transform.position = this.transform.position;
        swBlock.tag = "Switch";
    }

    // Big stone platform.
    private void SpawnStonePlatform1()
    {
        GameObject stonePlatform = (GameObject)Instantiate(stonePlatform1Prefab);
        stonePlatform.transform.position = this.transform.position;
        stonePlatform.tag = "Ground";
    }

    // Small stone paltforms.
    private void SpawnStonePlatform2()
    {
        GameObject stonePlatform = (GameObject)Instantiate(stonePlatform2Prefab);
        stonePlatform.transform.position = this.transform.position;
        stonePlatform.tag = "Ground";
    }

    // Spawn the bridge behind the level because the player needs to make the bridge appear via a switch.
    private void SpawnStoneBridge()
    {
        GameObject bridge = (GameObject)Instantiate(stonePlatform2Prefab);
        bridge.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
        bridge.tag = "StoneBridge";
        CloseBridge(0);
    }

    // Spawn a wall.
    private void SpawnWall1()
    {
        GameObject wall = (GameObject)Instantiate(wall1Prefab);
        wall.transform.position = this.transform.position;
    }

    // Another wall.
    private void SpawnWall2()
    {
        GameObject wall = (GameObject)Instantiate(wall2Prefab);
        wall.transform.position = this.transform.position;
    }

    // And the biggest wall.
    private void SpawnWall3()
    {
        GameObject wall = (GameObject)Instantiate(wall3Prefab);
        wall.transform.position = this.transform.position;
    }

    // My door to end the level.
    private void SpawnEndDoor()
    {
        GameObject endDoor = (GameObject)Instantiate(endDoorPrefab);
        endDoor.transform.position = this.transform.position;
        endDoor.tag = "EndDoor";
    }

    // The event used for my starblocks.
    private void Empty(StarBlock sb)
    {
        isStarblock = false;
        sb.Destroyed -= Empty;

        CloseSwitch(sb);
    }

    // When the player takes a star block out of a switch, this method is called to respawn the correct asset.
    private void CloseSwitch(StarBlock sb)
    {
        // Get all my switches and associate the correct ones to the right ones.
        GameObject[] switches = GameObject.FindGameObjectsWithTag("Switch");
        // Had to use Epsilon in order to get through a bug where the platform was not closing.
        if (sb.transform.position.x >= switches[0].transform.position.x - Mathf.Epsilon && sb.transform.position.x <= switches[0].transform.position.x + Mathf.Epsilon && sb.transform.position.y >= switches[0].transform.position.y - Mathf.Epsilon && sb.transform.position.y <= switches[0].transform.position.y + Mathf.Epsilon && sb != null)
        {
            CloseDoor(0);
        }
        else if (sb.transform.position.x >= switches[1].transform.position.x - Mathf.Epsilon && sb.transform.position.x <= switches[1].transform.position.x + Mathf.Epsilon && sb.transform.position.y >= switches[1].transform.position.y - Mathf.Epsilon && sb.transform.position.y <= switches[1].transform.position.y + Mathf.Epsilon && sb != null)
        {
            CloseDoor(1);
        }
        else if (sb.transform.position.x >= switches[2].transform.position.x - Mathf.Epsilon && sb.transform.position.x <= switches[2].transform.position.x + Mathf.Epsilon && sb.transform.position.y >= switches[2].transform.position.y - Mathf.Epsilon && sb.transform.position.y <= switches[2].transform.position.y + Mathf.Epsilon && sb != null)
        {
            CloseBridge(0);
        }
        else if (sb.transform.position.x >= switches[3].transform.position.x - Mathf.Epsilon && sb.transform.position.x <= switches[3].transform.position.x + Mathf.Epsilon && sb.transform.position.y >= switches[3].transform.position.y - Mathf.Epsilon && sb.transform.position.y <= switches[3].transform.position.y + Mathf.Epsilon && sb != null)
        {
            CloseDoor(2);
        }
        else if (sb.transform.position.x >= switches[4].transform.position.x - Mathf.Epsilon && sb.transform.position.x <= switches[4].transform.position.x + Mathf.Epsilon && sb.transform.position.y >= switches[4].transform.position.y - Mathf.Epsilon && sb.transform.position.y <= switches[4].transform.position.y + Mathf.Epsilon && sb != null)
        {
            CloseDoor(3);
        }
    }

    // Make the bridge appear on the screen using his z position.
    private void OpenBridge(int bridgeNumber)
    {
        GameObject[] bridgeRef = GameObject.FindGameObjectsWithTag("StoneBridge");
        bridgeRef[bridgeNumber].transform.position = new Vector3(bridgeRef[bridgeNumber].transform.position.x, bridgeRef[bridgeNumber].transform.position.y, 0);
        // Enable the collision.
        Collider2D coll = bridgeRef[bridgeNumber].GetComponent<Collider2D>();
        coll.enabled = true;
    }

    // Close the bridge using his z position.
    private void CloseBridge(int bridgeNumber)
    {
        GameObject[] bridgeRef = GameObject.FindGameObjectsWithTag("StoneBridge");
        bridgeRef[bridgeNumber].transform.position = new Vector3(bridgeRef[bridgeNumber].transform.position.x, bridgeRef[bridgeNumber].transform.position.y, 1);
        // Disable the collision
        Collider2D coll = bridgeRef[bridgeNumber].GetComponent<Collider2D>();
        coll.enabled = false;
    }
    
    // Open a door with his z axis.
    private void OpenDoor(int doorNumber)
    {
        // Set z position behind and disable the collider2D.
        GameObject[] doorRef = GameObject.FindGameObjectsWithTag("Door");
        doorRef[doorNumber].transform.position = new Vector3(doorRef[doorNumber].transform.position.x, doorRef[doorNumber].transform.position.y, 1);
        // Disable the collision so the player can pass
        Collider2D coll = doorRef[doorNumber].GetComponent<Collider2D>();
        coll.enabled = false;
    }

    // Close a door with his z axis.
    private void CloseDoor(int doorNumber)
    {
        // Set z position back and enable the collider2D.
        GameObject[] doorRef = GameObject.FindGameObjectsWithTag("Door");
        doorRef[doorNumber].transform.position = new Vector3(doorRef[doorNumber].transform.position.x, doorRef[doorNumber].transform.position.y, 0);
        // Enable the collision
        Collider2D coll = doorRef[doorNumber].GetComponent<Collider2D>();
        coll.enabled = true;
    }

    void OnMouseDown()
    {
        // Get my mouse pos on screen with world coordinate using the origin.
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if the range to pickup blocks is ok
        if (Mathf.Abs(mousePos.origin.x - myPlayer.transform.position.x) <= myPlayer.playerRange && Mathf.Abs(mousePos.origin.y - myPlayer.transform.position.y) <= myPlayer.playerRange && mousePos.origin.y >= myPlayer.transform.position.y - 0.1f)
        {
            // Switch for door #1.
            if (name == switch1 && myPlayer.inventoryStarBlocks > 0)
            {
                OpenDoor(0);
            }

            // Switch for door #2.
            if (name == switch2 && myPlayer.inventoryStarBlocks > 0)
            {
                OpenDoor(1);
            }

            // Switch for the bridge.
            if (name == switch3 && myPlayer.inventoryStarBlocks > 0)
            {
                OpenBridge(0);
            }

            // Switch for door #3.
            if (name == switch4 && myPlayer.inventoryStarBlocks > 0)
            {
                OpenDoor(2);
            }

            // Switch for door #4.
            if (name == switch5 && myPlayer.inventoryStarBlocks > 0)
            {
                OpenDoor(3);
            }

            // MAKE SURE TO PLACE BEHAVIORS BEFORE DELETING THE BLOCK !

            // Do I have any star blocks to place in my inventory?
            if (isStarblock == false && myPlayer.inventoryStarBlocks > 0)
            {
                StarBlock starBlock = (StarBlock)Instantiate(sbPrefab);
                starBlock.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.01f);
                // Start listening to my event.
                starBlock.Destroyed += Empty;
                isStarblock = true;
                // Make sure to take it out
                myPlayer.inventoryStarBlocks--;
            }
        }
    }
}