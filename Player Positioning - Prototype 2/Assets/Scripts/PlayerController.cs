using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {
	public float horizontalInput;
	public float speed = 15.0f;
	public float xRange = 10;
	public GameObject projectilePrefab;

	void Update() {
		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

		// These `if()`s will keep the player within the field of view.
		if(transform.position.x < -xRange) {
			transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
		} if(transform.position.x > xRange) {
			transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
		}

		// To shoot (when spacebar pressed):
		if(Input.GetKeyDown(KeyCode.Space)) {
			// Launch projectile
			Vector3 foodSpawnPos = new Vector3(transform.position.x, 2, transform.position.z); // Used just to make the pizza be at eye level and not on the floor.
			Instantiate(projectilePrefab, foodSpawnPos, projectilePrefab.transform.rotation);
		}
	}
}
