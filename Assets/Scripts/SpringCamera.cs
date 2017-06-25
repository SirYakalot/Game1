using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringCamera : MonoBehaviour {

    public object focus;
    private Transform startLoc;
    private float temp;
	// Use this for initialization
	void Start () {
        startLoc = transform;
        temp = transform.position.x + 3.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distFromSpringPos = transform.position.x - temp;
        float delta = ScriptFuncs.Spring(distFromSpringPos, 1.0f);
        delta *= Time.deltaTime;

        transform.position = new Vector3(transform.position.x + delta, transform.position.y, transform.position.z);
	}
}
