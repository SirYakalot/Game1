using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DONEXT! - just implement the while loop. also split into states. 
public class Communication : StateScript {

    //[do you like] iterate through all names - do you like jack?
    private List<string> questions;

	// Use this for initialization
	void Start ()
    {
        questions.Add("Do you like");
        questions.Add("Have you seen");

        (Go MenuClosed());
	}

    virtual IEnumerator MenuClosed ()
    {
        yeild return new WaitUntil(() => Input.GetButton("CommsMenu"));
        (Go OpenMenu());
    }

    virtual IEnumerator OpenMenu ()
    {
        // play some menu opening anim NOTE - might be nice to play this async actually... so that you can still interact with the menu while it opens
        // remember to ignore the button being held though...
        (Go MenuActive());
    }

    virtual IEnumerator MenuActive ()
    {
        while (true)
        {
            yeild return new WaitUntil(() => 
                (Input.GetButton("CommsMenu") || 
                 Input.GetButton("Select") ||
                 Input.GetButton("SelectUp") ||
                 Input.GetButton("SelectDown") ||
                 Input.GetButton("SelectLeft") ||
                 Input.GetButton("SelectRight"));
            
            if (Input.GetButton("CommsMenu")) {
                (Go CloseMenu());
            }
            else if (Input.GetButton("Select")) {
                (Go SpeakSentence());
            }
            else if (Input.GetButton("SelectUp")) {
                (Go CycleCurrentOptionUp());
            }
            else if (Input.GetButton("SelectDown")) {
                (Go CycleCurrentOptionDown());
            }
            // else if (Input.GetButton("SelectLeft")) {
                
            // }
            // else if (Input.GetButton("SelectRight")) {
                
            // }
            yield return new WaitFrames(1);
            //when selected - use the target chooser to ask the question
        }
    }

    virtual IEnumerator CloseMenu ()
    {
        (Go MenuClosed());
    }

    virtual IEnumerator SpeakSentence ()
    {
        //use all the currently selected pieces of the sentence to action it
    }

    virtual IEnumerator CycleCurrentOptionUp ()
    {
        //for now just cycle through the names? using 'do you like'. 
        //select the new person
        yield return new WaitUntil(() => Input.GetButtonUp("SelectUp"));
        (Go MenuActive());
    }

    virtual IEnumerator CycleCurrentOptionDown ()
    {
        //select the new person
        yield return new WaitUntil(() => Input.GetButtonUp("SelectDown"));
        (Go MenuActive());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}