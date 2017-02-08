using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when any behaviour is triggered, it cancels the others
//example - the left behaviour triggers even if you're in the middle of any other - 'bye then..' etc. 

//they essentially need an ambient behaviour, a thing you can do with them, or some things... reactions to things
//possibly need some function that you can call in a behaviour that specifies it can't be interrupted. extreme example - 

//also.... need the concept of a state change where you literally overwrite all the actions - like if their friend dies
//you'll want to override the approached behaviour etc. in this way we almost want to be able to specifiy these things as a
//behaviour set, and just switch them out. so possibly this should be restructured. Eve should own a 'set' which is what you script

//each subsequent set only overrides the funcs you've filled out - so the active set is comprised of the initial set plus overrides. 
//this means for a simple story advancement you just have to code a new interact behaviour and leave behaviour possibly.

//each set also owns a script table which has an appropriate line for each action.
// hi  			 bye then.        ouch
// hi again      bye again        ouch

//something like a punch would actually change the set, and the script table, so ouch would transition the set to something else. a different mood set. 
//so each state can advance its own story whithin the script table without having to create a new set for it. each set has a story essentially. 
public class eve : npc 
{
	// Use this for initialization
	void Start () 
	{
		interact = "Hey";
		walkedAwayFrom = "Bye then";
		approached = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//reverts back to this when any other behaviour finishes 
//	protected override IEnumerable //Default_start ()
//	{
//		base.Approached ();
//		//go and get ball
//	}

//	protected override void Default_update ()
//	{
//		
//		//play with ball
//	}
//
//	protected override IEnumerable Approached_start ()
//	{
//		
//		//have nice functions like - lookChill which would find the nearest chill action pack and do that
//	}
//
//	protected override void Approached_update ()
//	{
//		
//		//follow player
//	}


}
