using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Controller : MonoBehaviour 
{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;

	void Update() 
	{
		//movement
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) 
		{
			moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			moveDirection = Quaternion.LookRotation (ScriptFuncs.FlattenY(GameObject.Find ("camera").transform.forward)) * moveDirection;
		
			moveDirection *= speed;

			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
