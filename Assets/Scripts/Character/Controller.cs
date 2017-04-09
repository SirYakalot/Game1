using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Controller : MonoBehaviour 
{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public AnimationCurve jumpCurve;

	private Vector3 moveDirection = Vector3.zero;
	private float jumpPhase = 0.0f;



	enum MovementState
	{
		grounded,
		falling,
		jumping
	}

	private MovementState m_State = MovementState.falling;

	public Transform thisCamera;

	private float jumpOffPoint;

	void Update() 
	{
		//movement
		CharacterController controller = GetComponent<CharacterController>();

		switch (m_State) 
		{
		case MovementState.grounded:
			moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			moveDirection = Quaternion.LookRotation (ScriptFuncs.FlattenY(thisCamera.transform.forward)) * moveDirection;

			moveDirection *= speed;

			if (Input.GetButton("Jump"))
			{
				jumpOffPoint = transform.position.y;
				m_State = MovementState.jumping;
			}
			else if (!controller.isGrounded)
				m_State = MovementState.falling;
			break;
		case MovementState.jumping:
			
			jumpPhase += Time.deltaTime;
			float jumpDelta = jumpCurve.Evaluate(jumpPhase) - (transform.position.y - jumpOffPoint);
			moveDirection.y = jumpDelta;
			print(jumpDelta);
			print("modified position " + (transform.position.y - jumpOffPoint));
			print("phase = " + jumpPhase);



			if (controller.isGrounded)
			{
				jumpPhase = 0.0f;
				m_State = MovementState.grounded;
			}
			else if (jumpPhase >= 1.0) 
			{
				jumpPhase = 0.0f;
				print("phase over");
				m_State = MovementState.falling;
			}
			break;
		case MovementState.falling:
			moveDirection.y -= gravity * Time.deltaTime;

			if (controller.isGrounded)
				m_State = MovementState.grounded;
			break;
		default:
			break;
		}


		controller.Move(moveDirection * Time.deltaTime);
	}
}
