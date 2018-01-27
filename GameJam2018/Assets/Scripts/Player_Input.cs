using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour {
	private Rigidbody2D rb;
	private Player_ControllerAdapter controls;
	public int movementForce = 300;
	public int groundHorizontalAcceleration = 10;
	public GameObject projectile;
	public int firingStrength = 25;

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

	void Fire ()
	{
		var energy = GetComponent<Energy_Input> ();
		if (controls.HorizontalAim != 0 || controls.VerticalAim != 0 ) {
			var newProjectile = Instantiate (projectile);
			var newProjectileEnergy = newProjectile.GetComponent<Projectile_Input> ().energy;
			if (energy.Energy >= newProjectileEnergy) {
				Physics2D.IgnoreCollision (newProjectile.GetComponent<Collider2D> (), this.GetComponent<Collider2D> (), true);
				newProjectile.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
				var horizontal = controls.HorizontalAim;
				var vertical = controls.VerticalAim;
				var angleRadians = Mathf.Atan (vertical / horizontal);
				var angleDegrees = Mathf.Rad2Deg * angleRadians;
				if (horizontal < 0) {
					angleDegrees += 180;
				}
				var projectileForce = Quaternion.AngleAxis (angleDegrees, Vector3.forward) * new Vector3 (firingStrength, 0);
				newProjectile.GetComponent<Rigidbody2D> ().AddForce (projectileForce, ForceMode2D.Impulse);
			
				energy.UseEnergy (newProjectileEnergy);
			} else {
				Destroy (newProjectile);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMovement ();
		Fire ();
	}
}
