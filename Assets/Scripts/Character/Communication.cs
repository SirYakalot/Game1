using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : StateScript {

    //[do you like] iterate through all names - do you like jack?
    private List<string> questions = new List<string>();//this really needs to be a little struct that has the string and a neat way to index into the info
    private List<npc> names = new List<npc>();
    private int currentQuestionIndex = 0;
    private int currentNameIndex = 0;

	// Use this for initialization
	void Start ()
    {
        questions.Add("Do you like");
        questions.Add("Do you hate");

        names.AddRange(Globals.allNpcs);

        Go(MenuClosed());
    }

    private IEnumerator MenuClosed()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("CommsMenu"));
        yield return new WaitUntil(() => Input.GetButtonUp("CommsMenu"));
        Go(OpenMenu());
    }

    private IEnumerator OpenMenu()
    {
        // play some menu opening anim NOTE - might be nice to play this async actually... so that you can still interact with the menu while it opens
        // remember to ignore the button being held though...
        Go(MenuActive());
        yield return 0;
    }

    private IEnumerator MenuActive()
    {
        gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = 
            (
                questions[Mathf.Abs((questions.Count + currentQuestionIndex) % questions.Count)] + " " +
                names[Mathf.Abs((names.Count + currentNameIndex) % names.Count)]
            );
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
            else if (Input.GetButton("SelectLeft")) {
                yield return new WaitUntil(() => Input.GetButtonUp("SelectLeft"));
                Go(SelectNextField());
            }
            else if (Input.GetButton("SelectRight")) {
                yield return new WaitUntil(() => Input.GetButtonUp("SelectRight"));
                Go(SelectPrevField());
            }
            yield return new WaitForSeconds(1.0f);
            //when selected - use the target chooser to ask the question
        }
    }

    private IEnumerator CloseMenu()
    {
        Go(MenuClosed());
        yield return 0;
    }

    private IEnumerator SpeakSentence()
    {
        //use all the currently selected pieces of the sentence to action it
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = "";

        yield return new WaitForSeconds(0.5f);

        npc closestNPC = ScriptFuncs.GetNearestNpc();
        RelationshipInfo npcInfo = closestNPC.gameObject.GetComponentInChildren<RelationshipInfo>();
        int dataIndex = npcInfo.relationshipKeys.IndexOf(names[Mathf.Abs((names.Count + currentNameIndex) % names.Count)]);

        string question = questions[Mathf.Abs((questions.Count + currentQuestionIndex) % questions.Count)];

        //replace this with the strcut - there's a todo note at the top of the file about it
        if (string.Equals(question, "Do you like"))
        {
            closestNPC.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = npcInfo.relationshipValues[dataIndex].Like;
        }
        else if (string.Equals(question, "Do you hate"))
        {
            closestNPC.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = npcInfo.relationshipValues[dataIndex].Hate;
        }

        Go(MenuClosed());
        yield return 0;
    }

    private IEnumerator CycleCurrentOptionUp()
    {
        //for now just cycle through the names? using 'do you like'. 
        //select the new person
        currentQuestionIndex++;
        Go(MenuActive());
        yield return 0;
    }

    private IEnumerator CycleCurrentOptionDown()
    {
        //select the new person
        currentQuestionIndex--;
        Go(MenuActive());
        yield return 0;
    }
    
    private IEnumerator SelectNextField()
    {
        currentNameIndex++;
        Go(MenuActive());
        yield return 0;
    }

    private IEnumerator SelectPrevField()
    {
        currentNameIndex--;
        Go(MenuActive());
        yield return 0;
    }
}