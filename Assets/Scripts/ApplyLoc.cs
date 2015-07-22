using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApplyLoc : MonoBehaviour 
{
    // Variables used to set text.
    private Localizater loc;
    private Text text;

    private const string startButton = "StartButton";
    private const string quitButton = "QuitButton";
    private const string replayButton = "ReplayButton";

	void Start () 
    {
        // Get my localization gameobject on the scene.
        loc = Localizater.FindObjectOfType<Localizater>();
        // Get the text component.
        text = GetComponent<Text>();

        // Determine which tag is associated and write the correct text.
        switch(text.tag)
        {
            // Each case calls a function listed below.
            case startButton:
                StartButton("Start");
                break;
            case quitButton:
                QuitButton("Quit");
                break;
            case replayButton:
                ReplayButton("Replay");
                break;
            default:
                break;
        }
	}

    // All functions generating texts.
    private void StartButton(string ID)
    {
        text.text = loc.IDToWord(ID);
    }

    private void QuitButton(string ID)
    {
        text.text = loc.IDToWord(ID);
    }

    private void ReplayButton(string ID)
    {
        text.text = loc.IDToWord(ID);
    }
}
