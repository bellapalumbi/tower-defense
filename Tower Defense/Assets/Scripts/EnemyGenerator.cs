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
		Invoke("SpawnSwordsman", 5);
		Invoke("SpawnSwordsman", 8);
		Invoke("SpawnSwordsman", 11);
		Invoke("SpawnSwordsman", 15);
		Invoke("SpawnSwordsman", 18);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnSwordsman () {
		PickRow();
		Instantiate(swordsman,new Vector3 (-12, row, -0.5f), Quaternion.identity);
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
