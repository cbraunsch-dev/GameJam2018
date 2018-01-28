﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingProjectile_Input : MonoBehaviour {
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == Tags.Attacker) {
			animator.SetTrigger (Triggers.BeamCollide);
		}
	}
}
