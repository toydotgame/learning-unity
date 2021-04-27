using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private float speed = 15; // 20 is too fast.
	private float turnSpeed = 100;
	private float horizontalInput;
	private float forwardInput;

	// Start is called before the first frame update
	void Start() {} // I don't know if I can delete an unused method like `Start()`.

	// Update is called once per frame
	void Update() {
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical"); // By "vertical", it means _forward_ - along the road.

		transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
		transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
		//transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
	}
}
