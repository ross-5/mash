
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	private float horizontalMove;
	Vector2 move;
	Vector2 value;

	public float runSpeed = 40f;

	private bool FacingRight = true;
	
	public int TimesJumped;
	public int NumberOfJumps;

	private void OnMove(InputValue value)
	{
		// Gets the value of the joystick and translate it into a vector 2.  
		move = value.Get<Vector2>();
	}
	private void FixedUpdate()
	{

		if (FacingRight)
		{
			// Moves the player if facing right.
			Vector3 movement = new Vector3(move.x, 0, 0) * runSpeed * Time.deltaTime;
			transform.Translate(movement);
		}
		else
		{
			// Moves the player if facing left.
			Vector3 movement = new Vector3(-move.x, 0, 0) * runSpeed * Time.deltaTime;
			transform.Translate(movement);

		}
		
		horizontalMove = move.x;
		
		if (horizontalMove > 0 && !FacingRight)
		{
			Flip();
		}
		else if (horizontalMove < 0 && FacingRight)
		{
			Flip();
		}
	}
	private void OnJump()
	{
		// Let the player jump and checkes how many times he jumped.
		if (TimesJumped < NumberOfJumps)
		{
			TimesJumped += 1;
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
		}
	}
	private void Flip()
	{
		// Flips the player.
		FacingRight = !FacingRight;

		transform.Rotate(0, 180, 0);
	}


}
