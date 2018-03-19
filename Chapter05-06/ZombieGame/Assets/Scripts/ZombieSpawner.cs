using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
	public GameObject zombiePrefab;
	public float zombieSpawnFrequency;
	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			GameObject zombie = Instantiate (zombiePrefab);
			GameObject [] zombieSpawners = GameObject.FindGameObjectsWithTag ("SpawnPoint");
			zombie.transform.position = zombieSpawners [Random.Range (0, zombieSpawners.Length)].transform.position;
			yield return new WaitForSeconds (zombieSpawnFrequency);
		}
	}
}