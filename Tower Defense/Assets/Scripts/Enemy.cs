using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization

	public float speed = 0.04f;
	public int hitStrength;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed,0,0);
	}
}
