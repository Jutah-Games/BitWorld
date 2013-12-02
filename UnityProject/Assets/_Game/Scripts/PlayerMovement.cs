using UnityEngine;
using Parse;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

#region Variables
	public float movementSpeed = 2f;
	public float jumpSpeed = 2f;

	private float jumpMultiplier = 50f;
	private float movementMultiplier = 1f;

	private Transform groundCheck;

	private bool grounded = false;

	private string trueFalse;

#endregion

	void Awake () {
											// Import Animations Here!!
		groundCheck = transform.Find("groundCheck");
	}

	void Update() {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetKeyDown(KeyCode.Space) && grounded)
			rigidbody2D.AddForce(new Vector2(0f, jumpSpeed * jumpMultiplier));

		/*grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded)
			rigidbody2D.AddForce(new Vector2(0f, jumpSpeed * jumpMultiplier));*/
	}

	void FixedUpdate() {
		playerMovement();

	}

	void playerMovement() {
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(Vector3.left * movementSpeed * Time.deltaTime * movementMultiplier);
		
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Translate(Vector3.right * movementSpeed * Time.deltaTime * movementMultiplier);
	}

	void OnGUI() {
		if (grounded)
			trueFalse = "true";
		else
			trueFalse = "false";

		GUI.Box (new Rect(20, 20, 100, 25), "" + LayerMask.NameToLayer("Ground"));
	}
}
