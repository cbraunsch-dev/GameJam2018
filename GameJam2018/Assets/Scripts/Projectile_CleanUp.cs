using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_CleanUp : MonoBehaviour {

	public float timeToLive;
	private float remainingTimeToLive;

	// Use this for initialization
	void Start () {
		remainingTimeToLive = timeToLive;
	}

	// Update is called once per frame
	void Update () {
		remainingTimeToLive -= Time.deltaTime;
		if (remainingTimeToLive <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision2D collision) {
		Destroy (gameObject);
	}
}
