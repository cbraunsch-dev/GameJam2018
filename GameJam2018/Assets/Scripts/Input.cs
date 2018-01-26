using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {
	private Rigidbody2D rb;
	public int movementForce = 300;
	public int groundHorizontalAcceleration = 10;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		var controls = gameObject.GetComponent<Player_ControllerAdapter> ();
		float horizontalMovementVector = controls.HorizontalMovement;
		float verticalMovementVector = controls.VerticalMovement;
		var acceleration = groundHorizontalAcceleration;
		Vector2 horizontalForce = new Vector2 (horizontalMovementVector * acceleration, verticalMovementVector * acceleration);

		rb.velocity = horizontalForce;
	}
}
