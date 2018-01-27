using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker_Input : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == Tags.ChargingProjectile) {
			var particleEnergy = collider.gameObject.GetComponent<Projectile_Input> ().energy;
			GetComponent<Energy_Input> ().AddEnergy (particleEnergy);
			Destroy (collider.gameObject);
		}
	}
}
