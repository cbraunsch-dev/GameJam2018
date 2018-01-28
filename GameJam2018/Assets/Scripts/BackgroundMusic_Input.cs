using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic_Input : MonoBehaviour {

	private static BackgroundMusic_Input instance = null;
	public static BackgroundMusic_Input Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		var audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();
		DontDestroyOnLoad(this.gameObject);
	}
}


