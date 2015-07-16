using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class LoadLevel : MonoBehaviour 
{
    public string level;
    public AudioClip onClick;
    
	public void StartGame()
    {
        AudioSource.PlayClipAtPoint(onClick, new Vector3(0, 0, 0));
        Application.LoadLevel(level);
    }
}
