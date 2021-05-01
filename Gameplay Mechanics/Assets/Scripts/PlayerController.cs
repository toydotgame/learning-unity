using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float speed = 10f;
	private Rigidbody playerRigidbody;
	private GameObject focalPoint;
	private bool hasPowerup;
	private float powerupStrength = 15.0f;
	public GameObject powerupIndicator;

	private void Start() {
		playerRigidbody = GetComponent<Rigidbody>();
		focalPoint = GameObject.Find("Focal Point");
	}

	private void Update() {
		float forwardInput = Input.GetAxis("Vertical");
		playerRigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
		powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Powerup")) {
			hasPowerup = true;
			Destroy(other.gameObject);
			StartCoroutine(PowerupCountdownRoutine());
			powerupIndicator.gameObject.SetActive(true);
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag("Enemy") && hasPowerup) {
			Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

			Debug.Log("Collided with " + collision.gameObject.name + ", powerup set to " + hasPowerup);

			enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
		}
	}

	private IEnumerator PowerupCountdownRoutine() {
		yield return new WaitForSeconds(7);
		hasPowerup = false;
		powerupIndicator.gameObject.SetActive(false);
	}
}
