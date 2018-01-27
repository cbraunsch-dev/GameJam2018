using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Input : MonoBehaviour {
	private int health = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Collided with kitty");
		if (collider.tag == Tags.AttackingParticle) {
			var particleEnergy = collider.gameObject.GetComponent<Projectile_Input> ().energy;
			this.health -= particleEnergy;
			if (this.health <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
