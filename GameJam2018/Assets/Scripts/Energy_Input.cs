using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_Input : MonoBehaviour {
	private int maxEnergy = 20;
	private float flashSpeed = 5f;
	private Color flashColor = new Color (0f, 1f, 0f, 0.25f);
	private bool charged = false;
	public Slider energySlider;
	public Image energyImage;

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
		//IndicateCharge ();	
	}

	void IndicateCharge ()
	{
		if (energyImage != null) {
			if (charged) {
				energyImage.color = flashColor;
			} else {
				energyImage.color = Color.Lerp (energyImage.color, Color.clear, flashSpeed * Time.deltaTime);
			}
		}
		charged = false;
	}

	public void AddEnergy(int energy) {
		this.charged = true;
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
