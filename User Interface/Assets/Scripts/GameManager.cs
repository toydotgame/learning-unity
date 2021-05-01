﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
	public List<GameObject> targets;
	private float spawnRate = 1.0f;
	private int score;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public bool isGameActive;
	public Button restartButton;
	public GameObject titleScreen;

	private IEnumerator SpawnTarget() {
		while(isGameActive) {
			yield return new WaitForSeconds(spawnRate);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
		}
	}

	public void UpdateScore(int scoreToAdd) {
		score += scoreToAdd; // score = score + scoreToAdd
		scoreText.text = "Score: " + score;
		if(score < 0) {
			GameOver();
		}
	}

	public void GameOver() {
		gameOverText.gameObject.SetActive(true);
		isGameActive = false;
		restartButton.gameObject.SetActive(true);
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void StartGame(int difficulty) {
		titleScreen.gameObject.SetActive(false);
		isGameActive = true;
		spawnRate /= difficulty; // spawnRate = spawnRate / difficulty
		StartCoroutine(SpawnTarget());
		score = 0;
		scoreText.text = "Score: " + score;
	}
}
