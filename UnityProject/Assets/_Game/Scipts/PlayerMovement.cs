using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int movementSpeed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal") * movementSpeed);
	}
}
