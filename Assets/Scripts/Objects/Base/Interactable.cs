using UnityEngine;
using System.Collections;

//this is going to want to be some combination of an interface and abstract
public class Interactable : MonoBehaviour 
{
//	void OnEnable()
//	{
//		EventManager.OnRequestInteract += RequestedInteract;
//	}
//
//
//	void OnDisable()
//	{
//		EventManager.OnRequestInteract -= RequestedInteract;
//	}


	protected virtual void RequestedInteract ()
	{

	}
}