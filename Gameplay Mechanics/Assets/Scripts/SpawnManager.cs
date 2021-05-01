using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public GameObject enemyPrefab;
	private float spawnRange = 9;
	private int enemyCount;
	private int wave = 1;
	public GameObject powerupPrefab;

	private void Start() {
		Instantiate(powerupPrefab, generateRandomSpawnPosition(), powerupPrefab.transform.rotation);
		SpawnEnemyWave(wave);
	}

	private void Update() {
		enemyCount = FindObjectsOfType<Enemy>().Length;
		if(enemyCount == 0) {
			wave++;
			Instantiate(powerupPrefab, generateRandomSpawnPosition(), powerupPrefab.transform.rotation);
			SpawnEnemyWave(wave);
		}
	}

	private Vector3 generateRandomSpawnPosition() {
		/*
		 * I could have just put `randomSpawnPosition`'s definition above that `Instantiate()` and just used that.
		 * _But_, Unity Learn said to create a new method which returns a Vector3 and use that in the `Instantiate()` instead.
		 * 
		 * I guess it looks a bit big when I seperate it over newlines?
		 */
		Vector3 randomSpawnPosition = new Vector3(
			Random.Range(-spawnRange, spawnRange),
			0,
			Random.Range(-spawnRange, spawnRange)
		);
		return randomSpawnPosition;
	}

	private void SpawnEnemyWave(int enemiesToSpawn) {
		for(int i = 0; i < enemiesToSpawn; i++) {
			Instantiate(enemyPrefab, generateRandomSpawnPosition(), enemyPrefab.transform.rotation);
		}
	}
}
