using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Input : MonoBehaviour {
	private int health = 5;
	public float Damage { get; private set; } //The damage the cat inflicts on the Roomba upon contact

	// Use this for initialization
	void Start () {
		this.Damage = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == Tags.AttackingParticle) {
			var particleEnergy = collider.gameObject.GetComponent<Projectile_Input> ().energy;
			this.health -= particleEnergy;
			if (this.health <= 0) {
				var gameManager = GameObject.FindWithTag (Tags.GameManager);
				gameManager.GetComponent<GameManager_Input> ().DestroyCat (gameObject);
			}
		}
	}
}
