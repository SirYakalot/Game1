using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour 
{
	public delegate void InteractAction();
	public static event InteractAction OnRequestInteract;

	void Update ()
	{
		//it's weird that this is here - should be in controller
		//interact
		if (Input.GetButton ("Interact")) 
		{
			if(OnRequestInteract != null)
				OnRequestInteract();
		}
	}
}