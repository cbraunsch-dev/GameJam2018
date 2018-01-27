﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour {
	private Rigidbody2D rb;
	private Player_ControllerAdapter controls;
	public int movementForce = 300;
	public int groundHorizontalAcceleration = 10;
	public GameObject projectile;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		controls = gameObject.GetComponent<Player_ControllerAdapter> ();
	}

	void UpdateMovement ()
	{
		float horizontalMovementVector = controls.HorizontalMovement;
		float verticalMovementVector = controls.VerticalMovement;
		var acceleration = groundHorizontalAcceleration;
		Vector2 horizontalForce = new Vector2 (horizontalMovementVector * acceleration, verticalMovementVector * acceleration);
		rb.velocity = horizontalForce;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMovement ();

		if (controls.DidPressFireButton) {
			Debug.Log ("Fire ze missiles");
			var newProjectile = Instantiate (projectile);
			Physics2D.IgnoreCollision (newProjectile.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
			newProjectile.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);

			var projectileForce = Vector2.right * 50;
			newProjectile.GetComponent<Rigidbody2D> ().AddForce (projectileForce, ForceMode2D.Impulse);
		}
	}
}