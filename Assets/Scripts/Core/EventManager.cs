using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour 
{
	public delegate void InteractAction();
	public static event InteractAction OnRequestInteract;//I think I can call this and it will call the delegate in my class?



	void Update ()
	{
		//this should send out an event to all objects with registered coroutines
		if (Input.GetButton ("Interact")) 
		{
			if (OnRequestInteract != null) 
			{
				OnRequestInteract ();
			}

			//ScriptFuncs.GetNearestNpc().RequestedInteract();
		} 
	}
}