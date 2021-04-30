using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public GameObject[] animalPrefabs;
	private float spawnRangeX = 10;
	private float spawnPosZ = 20;
	private float startDelay = 2; // Seconds?
	private float spawnInterval = 1.5f; // **Why the `f`? Why?**

	void Start() {
		InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
	}

	public void SpawnAnimal() {
		Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
		int animalIndex = Random.Range(0, animalPrefabs.Length); // Random animal picker
		Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
	}
}
