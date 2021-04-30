using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
	public GameObject dogPrefab;

    void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
		}
	}
}
