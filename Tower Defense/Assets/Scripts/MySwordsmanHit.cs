using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySwordsmanHit : MonoBehaviour {

	// Use this for initialization
	
	public int myHealth;
	private bool hasSnapped;

	int enemyHP;

	int myhitStrength = 2;

	

	void OnTriggerEnter2D(Collider2D enemy) {
		hasSnapped = gameObject.GetComponent<DragDrop>().hasSnapped;
		if(hasSnapped) {
			Debug.Log ("trigger activated");
			if (enemy.gameObject.tag == "Enemy") {
				print("swordsman has hit enemy");
				Pushback(enemy);
				GetHit(enemy);
				MyHit(enemy);
			}
		}
	}

	void Pushback(Collider2D enemy) {
		print("myPushback called");
		enemy.gameObject.transform.Translate(-0.4f,0,0);
		gameObject.transform.Translate(0.4f, 0,0);

	}

	void GetHit(Collider2D enemy) {
		myHealth -= enemy.gameObject.GetComponent<Enemy>().hitStrength;
		if (myHealth <= 0) {
			Destroy(gameObject);
		}
	}

	void MyHit(Collider2D enemy) {
		enemy.gameObject.GetComponent<Enemy>().hitPoints -= myhitStrength;
		if (enemy.gameObject.GetComponent<Enemy>().hitPoints <= 0) {
			Destroy(enemy.gameObject);
		}
	}

}
