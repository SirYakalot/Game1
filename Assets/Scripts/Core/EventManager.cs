﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour 
{
//	public delegate void InteractAction();
//	public static event InteractAction OnRequestInteract;



	void Update ()
	{
		//it's weird that this is here - should be in controller
		//interact
		if (Input.GetButtonDown ("Interact")) 
		{
//			if (OnRequestInteract != null) 
//			{
//				OnRequestInteract ();
//			}

			ScriptFuncs.GetNearestNpc().RequestedInteract();
		} 
	}
}