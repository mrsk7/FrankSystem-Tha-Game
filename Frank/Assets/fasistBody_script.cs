﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fasistBody_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("OnCollisionEnter fasist body");
	}
}