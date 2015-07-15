using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

    public AudioClip onClick;

	public void CloseGame()
    {
        AudioSource.PlayClipAtPoint(onClick, new Vector3(0, 0, 0));
        Application.Quit();
    }
}
