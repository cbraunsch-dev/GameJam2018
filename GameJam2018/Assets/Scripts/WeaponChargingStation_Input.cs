using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChargingStation_Input : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == Tags.Charger) {
			var charger = collider.gameObject.GetComponent<Charger_Input> ();
			charger.StartCharging ();
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == Tags.Charger) {
			var charger = collider.gameObject.GetComponent<Charger_Input> ();
			charger.StopCharging ();
		}
	}
}
