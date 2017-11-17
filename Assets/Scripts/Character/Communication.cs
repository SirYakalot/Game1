using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DONEXT! - just implement the while loop. also split into states. 
public class Communication : StateScript {

    //[do you like] iterate through all names - do you like jack?
    private List<string> questions;

	// Use this for initialization
	void Start ()
    {
        questions.Add("Do you like");
        questions.Add("Have you seen");

        while (true)
        {
            //wait for input either iterate through the names or select

            //when selected - use the target chooser to ask the question
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}