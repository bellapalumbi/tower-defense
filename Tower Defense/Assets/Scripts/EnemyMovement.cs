﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization

	public float speed = 0.04f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed,0,0);
	}
}
