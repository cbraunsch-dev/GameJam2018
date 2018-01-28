using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Cat_Input : MonoBehaviour {
	private int health;
	private AIPath ai;
	private Animator animator;
	public float Damage { get; private set; } //The damage the cat inflicts on the Roomba upon contact
	public int StartingHealth { get; set; }

	// Use this for initialization
	void Start () {
		this.Damage = 0.2f;
		this.ai = GetComponent<AIPath> ();
		this.animator = GetComponent<Animator> ();
		this.health = StartingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetFloat ("Speed", ai.velocity.magnitude);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == Tags.AttackingParticle) {
			if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("TigerCat_Shock"))
			{
				animator.SetTrigger (Triggers.StartShocking);
			}

			var particleEnergy = collider.gameObject.GetComponent<Projectile_Input> ().energy;
			this.health -= particleEnergy;
			if (this.health <= 0) {
				var gameManager = GameObject.FindWithTag (Tags.GameManager);
				gameManager.GetComponent<GameManager_Input> ().DestroyCat (gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == Tags.Attacker || collision.collider.tag == Tags.Charger) {
			animator.SetTrigger (Triggers.CatStrike);	
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.collider.tag == Tags.Attacker || collision.collider.tag == Tags.Charger) {
			animator.SetTrigger (Triggers.CatIdle);
		}
	}
}
