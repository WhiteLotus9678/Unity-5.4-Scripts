using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHintsUi : MonoBehaviour {

    string hint;
    public Text hintText;
    float timer = 0f;
    int limit = 5;

    public void DisplayHint(string newHint) //has to be public to be called in Playercollisions
    {
        hintText.text = newHint;
        hintText.enabled = true;
    }

	// Use this for initialization
	void Start () {

        hintText = GetComponent<Text>();
	
	}

    // Update is called once per frame
    void Update() {

        if (hintText.enabled == true)
        {
            timer = timer + Time.deltaTime; //times the text

            if(timer > limit)
            {
                timer = 0;
                hintText.text = "";
                hintText.enabled = false;
            }
        }
        else
        {
            
        }

    }
}
