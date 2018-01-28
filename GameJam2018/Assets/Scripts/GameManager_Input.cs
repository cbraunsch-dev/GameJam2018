using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_Input : MonoBehaviour {
	private int numberOfCatsAliveAtATime = 5;
	private float delayBeforeSpawningNewCat = 3f;	//In seconds
	public GameObject tigerCat;
	public List<GameObject> spawnPoints = new List<GameObject>();
	public Text numberOfCatsKilledText;
	public List<AudioClip> catAudioClips = new List<AudioClip> ();
	private List<GameObject> cats = new List<GameObject>();
	private AudioSource catAudioSource;
	private float timeUntilSpawnNewCat;
	private int numberOfCatsKilled = 0;
	private bool catsAround = false;
	private float timeSinceLastCatSound = 0;
	private float timeBetweenCatSounds = 4;
	private float timeSinceLastCatStrengthening = 0;
	private float timeBetweenCatStrengthenings = 10;
	private const int initialCathStrength = 5;
	private const int catStrenghtIncrease = 3;
	private int catStrenght;

	// Use this for initialization
	void Start () {
		timeUntilSpawnNewCat = delayBeforeSpawningNewCat;
		this.UpdateKillCountText ();
		catAudioSource = GetComponent<AudioSource> ();
		catStrenght = initialCathStrength;
	}
	
	// Update is called once per frame
	void Update () {
		PlayCatSounds ();
		if (cats.Count < numberOfCatsAliveAtATime) {
			timeUntilSpawnNewCat -= Time.deltaTime;
			if (timeUntilSpawnNewCat <= 0) {
				//Spawn new cat
				var newCat = this.SpawnCat();
				var indexOfRandomSpawnPoint = Random.Range(0, spawnPoints.Count);
				var spawnPoint = spawnPoints [indexOfRandomSpawnPoint];
				newCat.transform.position = spawnPoint.transform.position;
				timeUntilSpawnNewCat = delayBeforeSpawningNewCat;
				this.cats.Add (newCat);
			}
		} else {
			timeUntilSpawnNewCat = delayBeforeSpawningNewCat;
		}

		IncreaseCatStrenght ();
	}

	private void IncreaseCatStrenght() {
		timeSinceLastCatStrengthening += Time.deltaTime;
		if (timeSinceLastCatStrengthening > timeBetweenCatStrengthenings) {
			timeSinceLastCatStrengthening = 0;
			this.catStrenght += catStrenghtIncrease;
		}
	}

	private void PlayCatSounds() {
		if (catsAround) {
			timeSinceLastCatSound += Time.deltaTime;
			if (timeSinceLastCatSound >= timeBetweenCatSounds) {
				timeSinceLastCatSound = 0;
				PlayRandomCatSound ();
			}
		} else {
			timeSinceLastCatSound = 0;
		}
	}

	private void PlayRandomCatSound() {
		var audioClipIndex = Random.Range (0, catAudioClips.Count);
		catAudioSource.clip = this.catAudioClips [audioClipIndex];
		catAudioSource.Play ();
	}

	private GameObject SpawnCat() {
		catsAround = true;
		var cat = Instantiate (tigerCat);
		cat.GetComponent<Cat_Input> ().StartingHealth = catStrenght;
		catsAround = true;
		return cat;
	}

	void UpdateKillCountText ()
	{
		this.numberOfCatsKilledText.text = "Cats vaporized: " + this.numberOfCatsKilled;
	}

	public void DestroyCat(GameObject cat){
		this.numberOfCatsKilled++;
		UpdateKillCountText ();
		this.cats.Remove (cat);
		Destroy (cat);
	}

	public static void PlayerDied() {
		SceneManager.LoadScene("GameOver");
	}
}
