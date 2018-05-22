using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CastleDefender : MonoBehaviour {

	int castleHealth;

	int castleHitStrength;

	public Text healthText;

	public Text GameOverText;
	
	// Use this for initialization
	void Start () {
		castleHealth = 100;
		castleHitStrength = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if (castleHealth <= 0) {
			print("gameover called");
			GameOver();
		}
	}

	void OnTriggerEnter2D(Collider2D enemy) {
		//Debug.Log ("trigger activated");
		if (enemy.gameObject.tag == "Enemy") {
			//print("swordsman has hit tower");
			Pushback(enemy);
			Hit(enemy);
			castleHealth -= enemy.gameObject.GetComponent<Enemy>().hitStrength;
		}
		//print("Castle health is now " + castleHealth);
		healthText.text = castleHealth + " / 100 HP";
	}

	void Pushback(Collider2D enemy) {
		enemy.gameObject.transform.Translate(-0.4f,0,0);
		enemy.gameObject.GetComponent<Enemy>().speed = 0.015f;
	}

	void GameOver() {
		SceneManager.LoadScene("Game Over");
	}

	void Hit(Collider2D enemy) {
		enemy.gameObject.GetComponent<Enemy>().hitPoints -= castleHitStrength;
		if (enemy.gameObject.GetComponent<Enemy>().hitPoints <= 0) {
			Destroy(enemy.gameObject);
		}
	}
}
