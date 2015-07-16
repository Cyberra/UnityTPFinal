using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI : MonoBehaviour 
{
    // Player reference.
    private Player myPlayer;

    // My blocks inside my UI.
    private GameObject block1;
    private GameObject block2;

	// Use this for initialization
	void Start () 
    {
        // Complete my references.
        myPlayer = FindObjectOfType<Player>();
        block1 = GameObject.FindGameObjectWithTag("Block1");
        block2 = GameObject.FindGameObjectWithTag("Block2");
	}
	
	void Update () 
    {
	    // Update to keep track for the number of blocks on the player and show it properly on the screen.
        UpdateUI();
	}

    private void UpdateUI()
    {
        // Set the correct states on each blocks.
        if (myPlayer.inventoryStarBlocks == 0)
        {
            block1.SetActive(false);
            block2.SetActive(false);
        }

        if (myPlayer.inventoryStarBlocks == 1)
        {
            block1.SetActive(true);
            block2.SetActive(false);
        }

        if (myPlayer.inventoryStarBlocks == 2)
        {
            block1.SetActive(true);
            block2.SetActive(true);
        }

    }
}
