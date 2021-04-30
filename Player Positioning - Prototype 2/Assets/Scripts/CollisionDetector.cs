using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {
	void OnTriggerEnter(Collider other) { // Destroy self and food when collision happens
		Destroy(gameObject);
		Destroy(other.gameObject);
	}
}
