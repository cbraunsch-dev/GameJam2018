using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ControllerAdapter : MonoBehaviour {
	private Controls_Xbox controls;

	// Use this for initialization
	void Start () {
		this.controls = GetComponent<Controls_Xbox> ();	
	}

	public float HorizontalMovement {
		get {
			return this.controls.LeftAnalogHorizontal;
		}
	}

	public float VerticalMovement {
		get {
			return this.controls.LeftAnalogVertical;
		}
	}

	public bool DidPressFireButton {
		get {
			return this.controls.DidPressButton_A;
		}
	}
}
