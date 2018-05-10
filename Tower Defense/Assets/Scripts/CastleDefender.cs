using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleDefender : MonoBehaviour {

	int castleHealth;

	public Text healthText;
	
	// Use this for initialization
	void Start () {
		castleHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D enemy) {
		//Debug.Log ("trigger activated");
		if (enemy.gameObject.tag == "Enemy") {
			print("swordsman has hit tower");
			Pushback(enemy);
			castleHealth -= enemy.gameObject.GetComponent<Enemy>().hitStrength;
		}
		print("Castle health is now " + castleHealth);
		healthText.text = castleHealth + " / 100 HP";
	}

	void Pushback(Collider2D enemy) {
		enemy.gameObject.transform.Translate(-0.4f,0,0);
		enemy.gameObject.GetComponent<Enemy>().speed = 0.015f;
	}
}
