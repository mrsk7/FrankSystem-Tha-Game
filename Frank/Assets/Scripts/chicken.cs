using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chicken_script : MonoBehaviour {

	public AudioSource audiosource;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayAudio(AudioClip audio) {
		audiosource.clip = audio;
		audiosource.Play ();
	}

}
