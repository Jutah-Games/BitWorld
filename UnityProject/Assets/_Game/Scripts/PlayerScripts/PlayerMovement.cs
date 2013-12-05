using UnityEngine;
using Parse;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

#region Variables
	public float movementSpeed = 2f;
	public float jumpHeight = 2f;

	private Transform groundCheck;

	public float maxMovementSpeed = 10f;

	private bool grounded = false;
	private bool jump = false;

#endregion

	void Awake () {
											// Import Animations Here!!
		groundCheck = transform.Find("groundCheck");
	}

	void Update() {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetButtonDown("Jump") && grounded)
			jump = true;

		if(Application.isEditor)
			if(Input.GetKeyDown(KeyCode.F5)) {
				transform.position = new Vector3(0, 4, 0);
				transform.rotation = new Quaternion(0, 0, 0, 0);
				rigidbody2D.velocity = new Vector2(0f, 0f);
			}
	}

	void FixedUpdate() {
		playerMovement();

		if (jump) {
			rigidbody2D.AddForce(new Vector2(0f, jumpHeight * 100f));

			jump = false;
		}

	}

	void playerMovement() {
		float h = Input.GetAxis ("Horizontal");

		if ((rigidbody2D.velocity.x * h < maxMovementSpeed)) 
			rigidbody2D.AddForce (Vector2.right * h * 2 * movementSpeed);

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxMovementSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxMovementSpeed, rigidbody2D.velocity.y);
		
	}

	void OnGUI() {
//		GUI.Box (new Rect (25, 25, 50, 25), "" + Input.GetAxis ("Horizontal"));
	}

}
