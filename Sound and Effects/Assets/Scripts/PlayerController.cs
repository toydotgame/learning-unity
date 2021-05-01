using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody playerRigidbody;
	public float jumpForce;
	public float gravityModifier;
	private bool isOnGround = true; // There's no need for this to be public. It's an internal variable to the player only.
	public bool gameOver = false; // public because SpawnManager and MoveLeft access it's value on collisions.
	private Animator playerAnim;
	public ParticleSystem explosionParticle;
	public ParticleSystem dirtParticle;
	public AudioClip jumpSound;
	public AudioClip crashSound;
	private AudioSource playerAudio;

	void Start() {
		playerRigidbody = GetComponent<Rigidbody>();
		Physics.gravity *= gravityModifier;
		/* 
		 * Note for class:
		 * `+=`, `-=`, `/=`, and `*=` modifiers.
		 * `x += y` can be written matematically (and alternatively (in code)) as `x = x + y`.
		 * INCREDIBLE SIMPLIFICATION
		 */
		playerAnim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
			playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			dirtParticle.Stop();
			isOnGround = false;
			playerAnim.SetTrigger("Jump_trig");
			playerAudio.PlayOneShot(jumpSound, 1.0f);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.CompareTag("Ground")) {
			dirtParticle.Play();
			isOnGround = true;
		} else if(collision.gameObject.CompareTag("Obstacle")) {
			gameOver = true;
			dirtParticle.Stop();
			Debug.Log("Game over!");
			explosionParticle.Play();
			playerAnim.SetBool("Death_b", true);
			playerAnim.SetInteger("DeathType_int", 1);
			playerAudio.PlayOneShot(crashSound, 1.0f);
		}
	}
}
