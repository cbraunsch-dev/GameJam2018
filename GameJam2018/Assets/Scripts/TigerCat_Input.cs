using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TigerCat_Input : MonoBehaviour {
	private GameObject attacker;
	private GameObject charger;
	private AIDestinationSetter destinationSetter;

	// Use this for initialization
	void Start () {
		attacker = GameObject.FindWithTag (Tags.Attacker);
		charger = GameObject.FindWithTag (Tags.Charger);
		destinationSetter = GetComponent<AIDestinationSetter> ();
	}
	
	// Update is called once per frame
	void Update () {
		var distanceToAttacker = Vector2.Distance (attacker.transform.position, this.transform.position);
		var distanceToCharger = Vector2.Distance (charger.transform.position, this.transform.position);
		if (distanceToAttacker < distanceToCharger) {
			destinationSetter.target = attacker.transform;
		} else {
			destinationSetter.target = charger.transform;
		}
	}
}
