using UnityEngine;
using System.Collections;

public class StarBlock : MonoBehaviour 
{
    // Delegate for tiles.
    public delegate void StarBlockDestroyed(StarBlock sb);
    public event StarBlockDestroyed Destroyed;

    // My player's reference.
    private Player myPlayer;

    void Awake()
    {
        // Set my reference.
        myPlayer = Player.FindObjectOfType<Player>();
    }

    private void DestroyBlock(Ray mousePos)
    {
        // Check if the range to pickup blocks is ok
        if (Mathf.Abs(mousePos.origin.x - myPlayer.transform.position.x) <= myPlayer.playerRange && Mathf.Abs(mousePos.origin.y - myPlayer.transform.position.y) <= myPlayer.playerRange && mousePos.origin.y >= myPlayer.transform.position.y - 0.1f)
        {
            // Add a Star Block to the player's inventory.
            myPlayer.inventoryStarBlocks++;
            // Event for Tiles.
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        // Get my mouse pos on screen with world coordinate using the origin.
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        DestroyBlock(mousePos);
    }

    void OnDestroy()
    {
        // Verify is has not been destroyed yet.
        if (Destroyed != null && this != null)
        {
            Destroyed(this);
        }
    }
}
