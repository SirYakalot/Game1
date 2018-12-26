using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateScript : MonoBehaviour {

	protected delegate void UpdateFunc();
	//protected delegate IEnumerator StartFunc ();
    //todo the first state should be called init or something, and then the function pointers can always point to them.

    //modify so that start is guaranteed to run for one frame before update kicks in. 
	// do we really need these? 
	UpdateFunc updateFunc;
	protected Coroutine startFunc;
	
	void Update () 
	{
        if (updateFunc != null)
            updateFunc();
    }

    //need to refactor this - if I wanted to add an update in a previous script, I would have to alter all the calls to Go(. so it's not good enough. 
    protected void Go(IEnumerator newStart, UpdateFunc newUpdate)
    {
        if (startFunc != null)
            StopCoroutine(startFunc);

        startFunc = StartCoroutine(newStart);

        updateFunc = newUpdate;
    }
}