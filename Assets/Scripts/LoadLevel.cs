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

    // Get main camera to find music used.
    private GameObject myCamera;
    
    void Start()
    {
        // Make sure the load level doesn't get destroy when changing scenes.
        DontDestroyOnLoad(this);
        // Get my camera.
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void StartScreen()
    {
        // Play the important click and load the title screen.
        AudioSource.PlayClipAtPoint(onClick, myCamera.transform.position);
        Application.LoadLevel(TitleScreen);
    }

	public void StartGame()
    {
        // Play the important click and load the level1.
        AudioSource.PlayClipAtPoint(onClick, myCamera.transform.position);
        Application.LoadLevel(level);
    }

    public void EndGame()
    {
        // Play the important click and load the end screen.
        Application.LoadLevel(endScreen);
        Destroy(this);
    }
}
