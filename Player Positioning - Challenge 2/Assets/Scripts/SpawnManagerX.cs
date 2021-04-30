using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour {
	public GameObject[] ballPrefabs;

	private float spawnLimitXLeft = -22;
	private float spawnLimitXRight = 7;
	private float spawnPosY = 30;
	
	private float startDelay = 1.0f;
	private float spawnInterval = 4f; // Cannot use randInt outside of method. rand is used to update this var on SpawnRandomBall(), however.

	void Start() {
		InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
	}

	/* 
	 * DEV NOTE:
	 * I decided against adding a cooldown for dog spawning.
	 * Not because I'm lazy and don't want to code.
	 * (I'm literally going through a week's worth of Unity Learn projects in the space of 4 hours)
	 * ...But because I thought a mutant mess of conjoined dogs looks funny.
	 */
	void SpawnRandomBall () {
		Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
		Instantiate(ballPrefabs[0], spawnPos, ballPrefabs[0].transform.rotation);
		spawnInterval = Random.Range(3f, 5f);
	}
}
