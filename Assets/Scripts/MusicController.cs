using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicController : MonoBehaviour 
{
    // All my music snapshot controllers.
    public AudioMixerSnapshot TitleScreen;
    public AudioMixerSnapshot Level1;
    public AudioMixerSnapshot EndScreen;

    // Snapshot used when updated
    private AudioMixerSnapshot currentSnapshot;

    // My music transition speed.
    private float transitionSpeed = 2.0f;

	void Start () 
    {
        // Start the music with the title screen one.
        currentSnapshot = TitleScreen;
        // Make it last through all scenes.
        DontDestroyOnLoad(this);
	}

    public void TransitTo(bool roar)
    {
        // If player begins the game.
        if (currentSnapshot == EndScreen)
        {
            currentSnapshot = TitleScreen;
        }

        // If player ends the first level.
        if (currentSnapshot == Level1)
        {
            currentSnapshot = EndScreen;
        }

        // If player restarts the game.
        if (currentSnapshot == TitleScreen)
        {
            currentSnapshot = Level1;
        }
        // Make the transition with the desired speed.
        currentSnapshot.TransitionTo(transitionSpeed);
    }
}
