using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Input : MonoBehaviour {
	private Rigidbody2D rb;
	private Player_ControllerAdapter controls;
	private bool allowedToSpawnProjectile;
	private float timeSinceLastFire;
	private bool isFiring = false;
	private float rateOfFire = 0.1f;
	private int groundHorizontalAcceleration = 5;
	private int firingStrength = 8;
	private float health = 20;
	private float flashSpeed = 5f;
	private Color flashColor = new Color (1f, 0f, 0f, 0.25f);
	private bool damaged = false;
	public GameObject projectile;
	public Slider healthSlider;
	public Image damageImage;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		controls = gameObject.GetComponent<Player_ControllerAdapter> ();
		allowedToSpawnProjectile = true;
		timeSinceLastFire = rateOfFire;
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
		if (allowedToSpawnProjectile && (controls.HorizontalAim != 0 || controls.VerticalAim != 0)) {
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
				newProjectile.transform.rotation = Quaternion.AngleAxis (angleDegrees, Vector3.forward);
			
				energy.UseEnergy (newProjectileEnergy);

				timeSinceLastFire = 0;
				allowedToSpawnProjectile = false;
				isFiring = true;
			} else {
				Destroy (newProjectile);
			}
		}
	}

	void UpdateContinuousFireState ()
	{
		if (isFiring) {
			timeSinceLastFire += Time.deltaTime;
			if (timeSinceLastFire >= rateOfFire) {
				allowedToSpawnProjectile = true;
			}
		}
		else {
			allowedToSpawnProjectile = true;
		}
	}

	void IndicateDamage ()
	{
		if (damaged) {
			damageImage.color = flashColor;
		}
		else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMovement ();
		Fire ();
		UpdateContinuousFireState ();
		IndicateDamage ();
	}

	void CheckCollisionWithCat (Collision2D collision)
	{
		if (collision.collider.tag == Tags.Cat) {
			var damageByCat = collision.collider.gameObject.GetComponent<Cat_Input> ().Damage;
			this.health -= damageByCat;
			this.healthSlider.value = this.health;
			this.damaged = true;
			if (this.health <= 0) {
				Destroy (gameObject);
				GameManager_Input.PlayerDied ();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		CheckCollisionWithCat (collision);
	}

	void OnCollisionStay2D(Collision2D collision) {
		CheckCollisionWithCat (collision);
	}
}
