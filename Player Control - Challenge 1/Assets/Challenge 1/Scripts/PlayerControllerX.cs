using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
	public float speed;
	public float rotationSpeed = 20;
	public float verticalInput;

	void FixedUpdate() {
        verticalInput = Input.GetAxis("Vertical"); // Up/Down Arrow keys to float verticalInput.
        transform.Translate(Vector3.forward * speed / 50);
		transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * verticalInput); // Pitch based on arrow key input.
    }
}
