using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public GameObject obstaclePrefab;
	private Vector3 spawnPos = new Vector3(25, 0, 0);
	private float spawnRate = 2; // I'll use this for both the delay and the spawn interval.
	private PlayerController playerControllerScript;

	void Start() {
		InvokeRepeating("SpawnObstacle", spawnRate, spawnRate);
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void SpawnObstacle() {
		if(playerControllerScript.gameOver == false) {
			Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
		}
	}
}
