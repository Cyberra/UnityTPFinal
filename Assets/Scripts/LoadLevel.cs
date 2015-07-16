using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class LoadLevel : MonoBehaviour 
{
    // String used to associate scenes in the scenes in build.
    private string TitleScreen = "TitleScreen";
    private string level = "Level1";
    private string endScreen = "EndScreen";

    // My click sound.
    public AudioClip onClick;
    
    void Start()
    {
        // Make sure the load level doesn't get destroy when changing scenes.
        DontDestroyOnLoad(this);
    }

    public void StartScreen()
    {
        // Play the important click and load the title screen.
        AudioSource.PlayClipAtPoint(onClick, new Vector3(0, 0, 0));
        Application.LoadLevel(TitleScreen);
    }

	public void StartGame()
    {
        // Play the important click and load the level1.
        AudioSource.PlayClipAtPoint(onClick, new Vector3(0, 0, 0));
        Application.LoadLevel(level);
    }

    public void EndGame()
    {
        // Play the important click and load the end screen.
        Application.LoadLevel(endScreen);
        Destroy(this);
    }
}
