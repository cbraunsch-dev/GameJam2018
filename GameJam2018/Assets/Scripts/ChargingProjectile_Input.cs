using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingProjectile_Input : MonoBehaviour {
	private int energy = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var attacker = GameObject.FindWithTag (Tags.Attacker);
		if (this.GetComponent<BoxCollider2D> ().bounds.Intersects (attacker.GetComponent<CircleCollider2D> ().bounds)) {
			attacker.GetComponent<Energy_Input> ().AddEnergy (this.energy);
			Destroy (gameObject);
		}
	}
}
