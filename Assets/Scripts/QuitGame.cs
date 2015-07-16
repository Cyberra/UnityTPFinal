using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

    // My Sound
    public AudioClip onClick;

    // Quit the game with the famous click sound.
	public void CloseGame()
    {
        AudioSource.PlayClipAtPoint(onClick, new Vector3(0, 0, 0));
        Application.Quit();
    }
}
