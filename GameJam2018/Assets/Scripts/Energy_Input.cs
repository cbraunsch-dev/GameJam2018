using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_Input : MonoBehaviour {
	private int maxEnergy = 20;
	public Slider energySlider;

	public int Energy {
		get;
		private set;
	}

	// Use this for initialization
	void Start () {
		this.Energy = this.maxEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddEnergy(int energy) {
		this.Energy += energy;
		if (this.Energy > this.maxEnergy) {
			this.Energy = this.maxEnergy;
		}
		this.energySlider.value = this.Energy;
	}

	public void UseEnergy(int energy) {
		this.Energy -= energy;
		this.energySlider.value = this.Energy;
		if (this.Energy < 0) {
			this.Energy = 0;
		}
	}
}
