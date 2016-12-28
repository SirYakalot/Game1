using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : Interactable {

	protected override void RequestedInteract ()//what is 'final'?
	{
		base.RequestedInteract ();//don't really need to do this

		print ("boink");//turn this into a nice object system
	}
}
