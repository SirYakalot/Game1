using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class ControllerCodeDriven : StateScript
{
	public float speed = 6.0F;
	public float jumpSpeed = 1.0F;
	public float gravity = 20.0F;
    public Transform m_Camera;

    [SerializeField] public bool m_RotationControlWhileJumping = false;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 storedDirection = Vector3.zero;
    private float jumpPhase = 0.0f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Go(FallingStart(), null);//, FallingUpdate());
    }

    private IEnumerator FallingStart()
    {
        yield return new WaitUntil(() => controller.isGrounded);
        Go(null, GroundedUpdate);
    }

    // private IEnumerator FallingUpdate()
    // {
    //     yield return new WaitUntil(() => controller.isGrounded);
    //     Go(());
    // }
    // private IEnumerator GroundedStart()
    // {
    //     yield return new WaitUntil(() => (!controller.isGrounded || Input.GetButton("Jump")));
    //     if (!controller.isGrounded)
    //     {
    //         Go(FallingStart());
    //     }
    //     else if (Input.GetButton("Jump"))
    //     {
    //         Go(JumpingStart());
    //     }
    // }

    private void GroundedUpdate()
    {
        if (!controller.isGrounded)
        {
            Go(FallingStart(), null);
        }
        else if (Input.GetButton("Jump"))
        {
            Go(JumpingStart(), JumpingUpdate);
        }

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection = Quaternion.LookRotation(ScriptFuncs.FlattenY(m_Camera.transform.forward)) * moveDirection;

        moveDirection *= (speed);// * speedMulitplier);
    }

    // jumping just controls the acceleration upwards
    private IEnumerator JumpingStart()
    {
        yield return new WaitUntil(() => !Input.GetButton("Jump"));
        Go(FallingStart(), null);
    }

    private void JumpingUpdate()
    {

    }
}
