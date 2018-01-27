using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Input : MonoBehaviour {
	public int Energy {
		get;
		private set;
	}

	// Use this for initialization
	void Start () {
		this.Energy = 10;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Energy: " + this.Energy);
	}

	public void AddEnergy(int energy) {
		this.Energy += energy;
		Debug.Log (">>Add energy " + energy + ". Total: " + this.Energy);
	}

	public void UseEnergy(int energy) {
		this.Energy -= energy;
		if (this.Energy < 0) {
			this.Energy = 0;
		}
	}
}
