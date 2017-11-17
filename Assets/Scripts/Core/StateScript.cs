using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateScript : MonoBehaviour {

	protected delegate void UpdateFunc();
	protected delegate IEnumerator StartFunc ();

	UpdateFunc updateFunc;
	StartFunc  startFunc;
	
	void Update () 
	{
		updateFunc();
	}

    protected void Go(StartFunc newStart)
    {
        StopCoroutine(startFunc());
        startFunc = newStart;
        StartCoroutine(newStart());
    }

    protected void Go(StartFunc newStart, UpdateFunc newUpdate)
	{
		StopCoroutine (startFunc());
		startFunc = newStart;
		StartCoroutine (newStart());

		updateFunc = newUpdate;
	}
}