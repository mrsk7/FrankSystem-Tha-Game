using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fasistHead_script : MonoBehaviour {
	private Animator parent_animator;
	public GameObject parent_object;
	// Use this for initialization
	void Start () {	
		parent_animator = GetComponentInParent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("In here bitch");
		if (collision.collider.gameObject.tag != "LegsCollider") {
			return;
		}
		parent_animator.SetTrigger ("fasistasTrig");
		Debug.Log ("Killing...");
		Destroy (parent_object, 0.5f);
		Debug.Log ("Killed");
	}
}
