using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger_Input : MonoBehaviour {
	private bool isCharging;
	private float remainingTimeUntilEnergyIncrease;

	public float timeBetweenEnergyIncrease = 1f;	//Time (in seconds) between the boosts of energy the charger receives while on the charging station
	public int energyIncrease = 5;	//The amount of energy the charger receives while on the charging station. Every N seconds (determined by timeBetweenEnergyIncrease) the player receives this much energy

	// Use this for initialization
	void Start () {
		isCharging = false;
		remainingTimeUntilEnergyIncrease = timeBetweenEnergyIncrease;
	}
	
	// Update is called once per frame
	void Update () {
		if (isCharging) {
			remainingTimeUntilEnergyIncrease -= Time.deltaTime;
			if (remainingTimeUntilEnergyIncrease <= 0) {
				remainingTimeUntilEnergyIncrease = timeBetweenEnergyIncrease;
				GetComponent<Energy_Input> ().AddEnergy (energyIncrease);
			}
		}
	}

	public void StartCharging() {
		isCharging = true;
		remainingTimeUntilEnergyIncrease = timeBetweenEnergyIncrease;
	}

	public void StopCharging() {
		isCharging = false;
	}
}
