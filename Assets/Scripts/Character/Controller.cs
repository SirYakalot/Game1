using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Controller : MonoBehaviour 
{
	public float speed = 6.0F;
	public float jumpSpeed = 1.0F;
	public float gravity = 20.0F;
	public AnimationCurve jumpCurve;

    private Vector3 moveDirection = Vector3.zero;
	private float jumpPhase = 0.0f;



	public enum MovementState
	{
		grounded,
		falling,
		jumping
	}

	public MovementState m_State = MovementState.falling;

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
                    jumpPhase = 0.0f;
                    jumpOffPoint = transform.position.y;
				    m_State = MovementState.jumping;
			    }
                else if (!controller.isGrounded)
                    m_State = MovementState.falling;
                break;
		    case MovementState.jumping:

                jumpPhase += Time.deltaTime * jumpSpeed;
                // float currentPos = transform.position.y - jumpOffPoint;
                float nextPos = jumpOffPoint + jumpCurve.Evaluate(jumpPhase);
                float movementDelta = nextPos - transform.position.y;

                //moveDirection takes a delta
			   // moveDirection.y = movementDelta;
                transform.position = new Vector3(transform.position.x, jumpOffPoint + jumpCurve.Evaluate(jumpPhase), transform.position.z);

                if (controller.isGrounded)
                {
                    m_State = MovementState.grounded;
                }
                else if (jumpPhase >= 1.0)
                {
                    m_State = MovementState.falling;
                }
                break;
		    case MovementState.falling:
                //rewrite to take curve into account
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
