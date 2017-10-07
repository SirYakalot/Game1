using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {

    public GameObject friendCharacter;

    protected string interact;
	protected string walkedAwayFrom;
	protected string approached;

	private bool justgotclicked = false;

	public void thisFunc()
	{
		justgotclicked = true;
	}

	void OnEnable()
	{
		EventManager.OnRequestInteract += thisFunc;
		Globals.allNpcs.Add(this);
	}

	public void Init()
	{
		StartCoroutine(Interact());
	}
//	void OnDisable()
//	{
//		EventManager.OnRequestInteract -= RequestedInteract;
//	}

	void Update()
	{
		//do some distance check between thresholds 
		// - and call walked away from and aproached
	}

	public virtual IEnumerator Interact()
	{
		print(interact);
		yield return new WaitUntil(() => justgotclicked);//the event managers func should return true or false
        gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = "I like" + friendCharacter;
        //		yield return new WaitUntil(() => thisFunc());//either wrap this as a lamda function or just use an event
        //		print("Might not be much yet but...");
        //		yield return new WaitUntil(() => thisFunc());
        //		print("It's gonna get there man");
    }

	//each one of these should be a state - update and start: so you can set little behaviours when things happen. dialogue should be a separate coroutine?
	//
	public virtual void WalkedAwayFrom ()
	{
		print(walkedAwayFrom);
	}

	public virtual void Approached ()
	{
		print(approached);
	}

	void OnGUI() 
	{

	}

	//PATTERN - the responses allw you to express your feelings as a player, whether that's total roleplay or
	//			allowing yourself to access something about your own life. However, the conversation reacts
	//			but does not branch, avoiding the problem of complexity explosion.

	//-statement
	//when you were a kid, you were afraid of the dark

	//-responses
	//fuck you
	//-reposnse reaction
	//...

	//I love you
	//-reposnse reaction
	//I love you too. so much. 

	//I'm still scared
	//-reposnse reaction
	//sweetie, I'm always here. 

	//continuing statement
	//it's so good to see you all grown up

	//this can be characters telling stories, or asking lines of questions. really anything, it's just a style of conversation. 
}
