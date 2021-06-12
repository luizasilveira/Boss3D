using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
//
	public Player player;
	public PlayerHealth playerHealth;
	public Text healthText;
	public Text infoText;
	private bool gameOver = false;
	private float resetTimer = 3f;

	void Start () {
		infoText.gameObject.SetActive (false);
		Cursor.visible = true;
	}

	void Update () {
		if (playerHealth.win == true) {
			gameOver = true;
			infoText.gameObject.SetActive (true);
			infoText.text = "Voce ganhou!";
		}

		if (playerHealth.Killed == true) {
			gameOver = true;
			infoText.gameObject.SetActive (true);
			infoText.text = "Voce perdeu!";
		}

		if (gameOver == true) {
			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0) {
				SceneManager.LoadScene ("Menu");
			}
		}
	}

	public void Menu(){
		SceneManager.LoadScene ("Menu");
		Time.timeScale = 1;
	}
}
