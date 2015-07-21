using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApplyLoc : MonoBehaviour 
{
    private Localizater loc;
    private Text text;

	void Start () 
    {
        loc = Localizater.FindObjectOfType<Localizater>();
        text = GetComponent<Text>();

        if (text.tag == "StartButton")
        {
            //text.text = loc.IDToWord("Start");
			loc.IDToWord("Start");
        }

        if (text.tag == "QuitButton")
        {

        }
	}
}
