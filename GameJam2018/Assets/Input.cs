using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {
	private Rigidbody2D rb;
	public int movementForce = 300;
	public int groundHorizontalAcceleration = 50;
	public int maxRunSpeed = 10;
	public int maxWalkSpeed = 5;
	public int maxJogSpeed = 8;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		var controls = gameObject.GetComponent<Player_ControllerAdapter> ();
		float groundMovement = controls.HorizontalMovement;
		var acceleration = groundHorizontalAcceleration;
		Vector3 horizontalForce = new Vector3 (groundMovement * acceleration, 0.0f, 0);
		var leftAnalogAbsValue = Mathf.Abs (groundMovement);
		var maxGroundSpeed = maxRunSpeed;
		if (leftAnalogAbsValue < 0.5) {
			maxGroundSpeed = maxWalkSpeed;
		}  else if (leftAnalogAbsValue < 0.75) {
			maxGroundSpeed = maxJogSpeed;
		}
		MovementHelper.limitHorizontalVelocityToMaximum (gameObject.GetComponent<Rigidbody>(), maxGroundSpeed, horizontalForce);
	}
}
