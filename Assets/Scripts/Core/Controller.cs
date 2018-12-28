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
    public Transform m_Camera;

    [SerializeField] public bool m_RotationControlWhileJumping = false;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 storedDirection = Vector3.zero;
    private float jumpPhase = 0.0f;

	public enum MovementState
	{
		grounded,
		falling,
		jumping
	}

	public MovementState m_State = MovementState.falling;

	private float jumpOffPoint;

	void FixedUpdate() 
	{
		//movement
		CharacterController controller = GetComponent<CharacterController>();

		switch (m_State) 
		{
            case MovementState.grounded:
                PlayerMove(1.0f);
                ApplyRotation();

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
                //controller doesn't rotate in the air, should skid out if there's a lot of forward momenntum

                if (m_RotationControlWhileJumping)
                {
                    moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                    moveDirection = Quaternion.LookRotation(ScriptFuncs.FlattenY(m_Camera.transform.forward)) * moveDirection;

                    moveDirection *= (speed * 1.0f);
                }
                
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
                else if (jumpPhase >= jumpCurve[jumpCurve.length - 1].time)
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

    private void ApplyRotation()
    {
        Vector3 eulerCamRotation = m_Camera.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0.0f, eulerCamRotation.y, 0.0f);
    }

    private void PlayerMove(float speedMulitplier)
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection = Quaternion.LookRotation(ScriptFuncs.FlattenY(m_Camera.transform.forward)) * moveDirection;

        moveDirection *= (speed * speedMulitplier);
    }
}
