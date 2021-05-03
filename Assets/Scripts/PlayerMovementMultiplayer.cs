using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovementMultiplayer : NetworkBehaviour {

	public CharacterController2D controller;

	public Animator animator;

	public Joystick joystick;

	public static bool lockMovement = false;

	public static float runSpeed = 20f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	bool isMobile = false;
	
	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) return;

		if (lockMovement == false) {

			if (isMobile)
			{
				if (joystick.Horizontal >= .2f)
				{
					horizontalMove = runSpeed;
				}
				else if (joystick.Horizontal <= -.2f)
				{
					horizontalMove = -runSpeed;
				}
				else
				{
					horizontalMove = 0;
				}
			} else
            {
				horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			}

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
			}

			if (Input.GetButtonDown("Crouch"))
			{
				crouch = true;
			} else if (Input.GetButtonUp("Crouch"))
			{
				crouch = false;
			}
		}
	}

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public void Jump()
    {
		jump = true;

	}
}
