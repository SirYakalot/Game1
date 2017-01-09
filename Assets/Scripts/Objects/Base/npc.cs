using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {

	protected string interact;
	protected string walkedAwayFrom;
	protected string approached;

	void OnEnable()
	{
		EventManager.OnRequestInteract += RequestedInteract;
	}


	void OnDisable()
	{
		EventManager.OnRequestInteract -= RequestedInteract;
	}

	void Update()
	{
		//do some distance check between thresholds 
		// - and call walked away from and aproached
	}

	//shouldn't this be override?
	protected virtual void RequestedInteract ()
	{
		print(interact);
	}

	protected virtual void WalkedAwayFrom ()
	{
		print(walkedAwayFrom);
	}

	protected virtual void Approached ()
	{
		print(approached);
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
