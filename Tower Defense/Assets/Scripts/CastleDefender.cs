using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDefender : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//Debug.Log ("trigger activated");
		if (collider.gameObject.name == "Swordsman") {
			print("swordsman has hit tower");
			Pushback(collider);
		}
	}

	void Pushback(Collider2D enemy) {
		enemy.gameObject.transform.Translate(-0.4f,0,0);
		enemy.gameObject.GetComponent<EnemyMovement>().speed = 0.015f;
	}
}
