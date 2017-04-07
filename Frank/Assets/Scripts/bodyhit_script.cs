using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyhit_script : MonoBehaviour {
	float time_to_live;
	Animator anim;
	AudioSource audios;
	bool dead;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		audios = GetComponent<AudioSource>();
		time_to_live = 2;
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("HIT Enter");
		if (dead)
			return;
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "EnemyChicken") {
			anim.SetBool ("isHit", true);
			Debug.Log ("isHit");
			if (!audios.isPlaying) {
				audios.Play ();
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		Debug.Log ("HIT Exit");
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "EnemyChicken") {
			anim.SetBool ("isHit", false);
			Debug.Log ("not isHit");
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		Debug.Log ("HIT Stay");
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "EnemyChicken") {
			time_to_live -= Time.deltaTime;
		}
		if (time_to_live <= 0) {
			anim.SetBool("isHit", false);
			dead = true;
			anim.Play ("DieFrank");
			Destroy (gameObject,2f);
			//Application.LoadLevel ("Testing2");
		}
	}
}
