using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	private Rigidbody targetRigidbody;
	private float minSpeed = 12;
	private float maxSpeed = 16;
	private float maxTorque = 10;
	private float xRange = 4;
	private float ySpawnPos = -6;
	private GameManager gameManager;
	public int pointValue;
	public ParticleSystem explosionParticle;

	private void Start() {
		targetRigidbody = GetComponent<Rigidbody>();
		targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
		targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
		transform.position = randomSpawnPosition();
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

	private Vector3 RandomForce() {
		return Vector3.up * Random.Range(minSpeed, maxSpeed);
	}

	private float RandomTorque() {
		return Random.Range(-maxTorque, maxTorque);
	}

	private Vector3 randomSpawnPosition() {
		return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
	}

	private void OnMouseDown() {
		if(gameManager.isGameActive) {
			Destroy(gameObject);
			Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
			gameManager.UpdateScore(pointValue);
		}
	}

	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		if(!gameObject.CompareTag("Bad")) {
			gameManager.GameOver();
		}
	}
}
