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



// query relationships 

//game starts off - travelling matchmaker. little puzzle game where you have to solve each level by finding the two people who like each other. it soon twists and turns into a strange murder mystery. 


// very simply one of the things that you can do is ask any character about any other. going forward maybe you have to meet the characters to be able to bring them up. or you get told about them. 
// so someone could lie to you, when you ask about them they've never heard of them
// you should be able to compose your sentences by choosing the components - do 'you / they / she' 'like / hate' 'you / them' etc... (knowing what others think of them is probably a bit advanced)
public class eve : npc
{
	// Use this for initialization
	void Start () 
	{
		interact = "Hey";
		walkedAwayFrom = "Bye then";
		approached = "";
		Init();//don't want to have to do this here
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
