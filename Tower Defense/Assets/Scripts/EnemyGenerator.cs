using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject swordsman;

	float row;

	
	// Use this for initialization
	void Start () {
		SpawnSwordsman();
		Invoke("SpawnSwordsman", 3);
		Invoke("SpawnSwordsman", 4);
		Invoke("SpawnSwordsman", 7);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnSwordsman () {
		PickRow();
		Instantiate(swordsman,new Vector3 (-9, row, -0.5f),Quaternion.identity);
	}

	float PickRow(){
		row = (Mathf.Round(Random.Range(0.5f,4.49f)));
		//print(row);
		if (row == 1) {
			row = 1.35f;
		}
		if (row == 2) {
			row = -0.62f;
		}
		if (row == 3) {
			row = -2.34f;
		}
		if (row == 4) {
			row = -4f;
		}
		return row;
	}

	
}
