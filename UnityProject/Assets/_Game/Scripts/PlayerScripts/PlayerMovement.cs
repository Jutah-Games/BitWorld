using UnityEngine;
using Parse;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

#region Variables
	public float movementSpeed = 2f;
	public float jumpSpeed = 2f;

	private float jumpMultiplier = 100f;
	private float movementMultiplier = 1f;

	private Transform groundCheck;

	private bool grounded = false;
	private bool jump = false;

	private string trueFalse;

	private float value = 5;

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
			}

		/*grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded)
			rigidbody2D.AddForce(new Vector2(0f, jumpSpeed * jumpMultiplier));*/
	}

	void FixedUpdate() {
		playerMovement();

		if (jump) {
			rigidbody2D.AddForce(new Vector2(0f, jumpSpeed * jumpMultiplier));

			jump = false;
		}

	}

	void playerMovement() {
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(Vector3.left * movementSpeed * Time.deltaTime * movementMultiplier);
		
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Translate(Vector3.right * movementSpeed * Time.deltaTime * movementMultiplier);
	}

}
