using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : StateScript {

    //[do you like] iterate through all names - do you like jack?
    private List<string> questions = new List<string>();
    private int currentIndex = 0;

	// Use this for initialization
	void Start ()
    {
        questions.Add("Do you like");
        questions.Add("Have you seen");

        Go(MenuClosed());
    }

    private IEnumerator MenuClosed()
    {
        print("menu closed");
        yield return new WaitUntil(() => Input.GetButtonDown("CommsMenu"));
        yield return new WaitUntil(() => Input.GetButtonUp("CommsMenu"));
        Go(OpenMenu());
    }

    private IEnumerator OpenMenu()
    {
        // play some menu opening anim NOTE - might be nice to play this async actually... so that you can still interact with the menu while it opens
        // remember to ignore the button being held though...
        print("menu open");
        Go(MenuActive());
        yield return 0;
    }

    private IEnumerator MenuActive()
    {
        print("and active");
        while (true)
        {
            yield return new WaitUntil(() =>
                (Input.GetButton("CommsMenu") ||
                 Input.GetButton("Select") ||
                 Input.GetButton("SelectUp") ||
                 Input.GetButton("SelectDown") ||
                 Input.GetButton("SelectLeft") ||
                 Input.GetButton("SelectRight")));

            if (Input.GetButton("CommsMenu"))
            {
                yield return new WaitUntil(() => Input.GetButtonUp("CommsMenu"));
                Go(CloseMenu());
            }
            else if (Input.GetButton("Select"))
            {
                yield return new WaitUntil(() => Input.GetButtonUp("Select"));
                Go(SpeakSentence());
            }
            else if (Input.GetButton("SelectUp"))
            {
                yield return new WaitUntil(() => Input.GetButtonUp("SelectUp"));
                Go(CycleCurrentOptionUp());
            }
            else if (Input.GetButton("SelectDown"))
            {
                yield return new WaitUntil(() => Input.GetButtonUp("SelectDown"));
                Go(CycleCurrentOptionDown());
            }
            // else if (Input.GetButton("SelectLeft")) {

            // }
            // else if (Input.GetButton("SelectRight")) {

            // }
            yield return new WaitForSeconds(1.0f);
            //when selected - use the target chooser to ask the question
        }
    }

    private IEnumerator CloseMenu()
    {
        print("closing menu");
        Go(MenuClosed());
        yield return 0;
    }

    private IEnumerator SpeakSentence()
    {
        //use all the currently selected pieces of the sentence to action it
        print(questions[Mathf.Abs((questions.Count + currentIndex) % questions.Count)]);
        Go(MenuClosed());
        yield return 0;
    }

    private IEnumerator CycleCurrentOptionUp()
    {
        //for now just cycle through the names? using 'do you like'. 
        //select the new person
        print("up");
        currentIndex++;
        Go(MenuActive());
        yield return 0;
    }

    private IEnumerator CycleCurrentOptionDown()
    {
        //select the new person
        print("down");
        currentIndex--;
        Go(MenuActive());
        yield return 0;
    }
}