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
	protected IEnumerator startFunc;
	
	void Update () 
	{
        if (updateFunc != null)
            updateFunc();
    }

    protected void Go(IEnumerator newStart)
    {
        if (startFunc != null)
            StopCoroutine(startFunc);

        startFunc = newStart;
        StartCoroutine(newStart);

        updateFunc = null;
    }

    protected void Go(IEnumerator newStart, UpdateFunc newUpdate)
    {
        if (startFunc != null)
            StopCoroutine(startFunc);

        startFunc = newStart;
        StartCoroutine(newStart);

        updateFunc = newUpdate;
    }

    protected void Go(UpdateFunc newUpdate)
    {
        if (startFunc != null)
            StopCoroutine(startFunc);

        updateFunc = newUpdate;
    }
}