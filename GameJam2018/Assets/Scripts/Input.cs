using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {
	private Rigidbody2D rb;
	public int movementForce = 300;
	public int groundHorizontalAcceleration = 10;
	public GameObject partner;
	public string name;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void UpdateMovement ()
	{
		var controls = gameObject.GetComponent<Player_ControllerAdapter> ();
		float horizontalMovementVector = controls.HorizontalMovement;
		float verticalMovementVector = controls.VerticalMovement;
		var acceleration = groundHorizontalAcceleration;
		Vector2 horizontalForce = new Vector2 (horizontalMovementVector * acceleration, verticalMovementVector * acceleration);
		rb.velocity = horizontalForce;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMovement ();

		RaycastHit2D hit;
		var rayDirection = transform.position - partner.transform.position;
		var rayHit = Physics2D.Raycast (partner.transform.position, rayDirection);
		Debug.Log (name + " at " + transform.position + " has hit partner at: " + rayHit.transform.position);
		//Debug.Log("Ray dir: " + rayDirection);
	}
}
