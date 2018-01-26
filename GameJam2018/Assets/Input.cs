using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Input : MonoBehaviour {
	private Rigidbody2D rb;
	public int movementForce = 300;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (Vector2.left * this.movementForce);

		var buttonDown = XCI.GetButtonDown (XboxButton.A);
		if (buttonDown) {
			Debug.Log ("Button pressed: " + buttonDown);
		}
	}
}
