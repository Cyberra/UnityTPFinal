using UnityEngine;
using System.Collections;

public class StarBlock : MonoBehaviour 
{
    public delegate void StarBlockDestroyed(StarBlock sb);
    public event StarBlockDestroyed Destroyed;
    
    void OnMouseDown()
    {
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
