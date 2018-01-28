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
	private List<GameObject> cats = new List<GameObject>();
	private float timeUntilSpawnNewCat;
	private int numberOfCatsKilled = 0;

	// Use this for initialization
	void Start () {
		timeUntilSpawnNewCat = delayBeforeSpawningNewCat;
		this.UpdateKillCountText ();
	}
	
	// Update is called once per frame
	void Update () {
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
	}

	private GameObject SpawnCat() {
		var cat = Instantiate (tigerCat);
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
