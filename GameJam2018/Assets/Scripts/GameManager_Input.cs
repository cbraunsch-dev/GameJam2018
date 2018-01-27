using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameManager_Input : MonoBehaviour {
	public int numberOfCatsAliveAtATime = 5;
	public float delayBeforeSpawningNewCat = 3f;	//In seconds
	public GameObject whiteCat;
	public GameObject tigerCat;
	public List<GameObject> spawnPoints = new List<GameObject>();
	private List<GameObject> cats = new List<GameObject>();
	private float timeUntilSpawnNewCat;

	// Use this for initialization
	void Start () {
		timeUntilSpawnNewCat = delayBeforeSpawningNewCat;
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
		var randomNr = Random.Range(0, 10);
		//if (randomNr >= 5) {
			var cat = Instantiate (tigerCat);
			cat.GetComponent<AIDestinationSetter> ().target = GameObject.FindWithTag (Tags.Charger).transform;
			return cat;
		/*} else {
			return Instantiate(whiteCat);
		}*/
	}

	public void DestroyCat(GameObject cat){
		this.cats.Remove (cat);
		Destroy (cat);
	}
}
