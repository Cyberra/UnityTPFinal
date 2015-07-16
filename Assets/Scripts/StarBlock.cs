using UnityEngine;
using System.Collections;

public class StarBlock : MonoBehaviour 
{
    public delegate void StarBlockDestroyed(StarBlock sb);
    public event StarBlockDestroyed Destroyed;

    private Player myPlayer;

    void Awake()
    {
        myPlayer = Player.FindObjectOfType<Player>();
    }

    void OnMouseDown()
    {
        myPlayer.inventoryStarBlocks++;
        Debug.Log(myPlayer.inventoryStarBlocks);
        // Event for Tiles.
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        // Verify is has not been destroyed yet.
        if (Destroyed != null)
        {
            Destroyed(this);
        }
    }
}
