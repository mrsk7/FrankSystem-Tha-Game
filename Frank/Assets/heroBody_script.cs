using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroBody_script : MonoBehaviour {
	public GameObject parent_object;
	float time_to_live;
	Animator anim;
	AudioSource audios;
	bool dead;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
		audios = GetComponentInParent<AudioSource>();
		time_to_live = 2;
		dead = false;
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("OnCollisionEnter");
		if (dead)
			return;
		if (collision.gameObject.tag == "BodyCollider" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "EnemyChicken") {
			Debug.Log ("Enter: Hit by body or something else");
			anim.SetBool ("isHit", true);
			if (!audios.isPlaying) {
				audios.Play ();
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		Debug.Log ("OnCollisionExit");
		if (collision.gameObject.tag == "BodyCollider" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "EnemyChicken") {
			anim.SetBool ("isHit", false);
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		Debug.Log ("OnCollisionStay");
		if (collision.gameObject.tag == "BodyCollider" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "EnemyChicken") {
			time_to_live -= Time.deltaTime;
			Debug.Log ("Stay: Hit by body or something else");
		}
		if (time_to_live <= 0) {
			anim.SetBool("isHit", false);
			dead = true;
			anim.Play ("DieFrank");
			Destroy (parent_object,2f);
			//Application.LoadLevel ("Testing2");
		}
	}
}
