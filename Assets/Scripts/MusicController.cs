using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicController : MonoBehaviour 
{
    public AudioMixerSnapshot TitleScreen;
    public AudioMixerSnapshot Level1;
    public AudioMixerSnapshot EndScreen;

    private AudioMixerSnapshot currentSnapshot;

	void Start () 
    {
        currentSnapshot = TitleScreen;
        DontDestroyOnLoad(this);
	}

    public void TransitTo(bool nextMusic)
    {
        if (currentSnapshot == TitleScreen)
        {
            currentSnapshot = nextMusic ? TitleScreen : Level1;
        }

        if (currentSnapshot == Level1)
        {
            currentSnapshot = EndScreen;
        }

        if (currentSnapshot == EndScreen)
        {
            currentSnapshot = TitleScreen;
        }

        currentSnapshot.TransitionTo(2.0f);
    }
}
