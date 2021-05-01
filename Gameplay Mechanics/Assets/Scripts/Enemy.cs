using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed;
	private Rigidbody enemyRigidbody;
	private GameObject player;

	private void Start() {
		enemyRigidbody = GetComponent<Rigidbody>();
		player = GameObject.Find("Player");
	}

	private void Update() {
		Vector3 lookDirection = (player.transform.position - transform.position).normalized;
		enemyRigidbody.AddForce(lookDirection * speed);

		if(transform.position.y < -10) {
			Destroy(gameObject);
		}
	}
}
