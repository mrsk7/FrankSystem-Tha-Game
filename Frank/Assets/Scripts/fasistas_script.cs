using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fasistas_script : MonoBehaviour {

	Animator anim;
	public AudioSource audios;
	public AudioSource audioF;
	public AudioClip dieSound;
	public AudioClip chickenSound;

	public GameObject hero;
	public bool facingRight;
	public bool chicken;
	public float speed;

	// Use this for initialization
	void Start () {
		facingRight = true;
		audios = GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		hero = GameObject.Find ("Egw");
		chicken = false;
		speed = 5f;
	}

	void PlayDeathSound() {
		AudioSource.PlayClipAtPoint (dieSound, transform.position);
	}

	// Update is called once per frame
	void Update () {
		if (transform.tag == "Enemy")
			goto next;
		GameObject[] endunamei = GameObject.FindGameObjectsWithTag ("EnemyChicken");
		if (endunamei.Length == 1  && !chicken) {
			chicken = true;
			audios.Play ();
			speed += 10f;
			anim.SetBool ("alone", true);
		}
		//transform.Translate (new Vector3 (5 * Time.deltaTime, 0, 0));
		next:
		float xDir = hero.transform.position.x - transform.position.x;
		if (chicken) {
			transform.position = Vector3.MoveTowards (transform.position, hero.transform.position, -speed * Time.deltaTime);
			if ((xDir > 0 && facingRight) || (xDir < 0 && !facingRight)) {
				ChangeDirection ();
			}
		} else {
			if (Vector3.Distance (transform.position, hero.transform.position) < 40f) {
				transform.position = Vector3.MoveTowards (transform.position, hero.transform.position, speed * Time.deltaTime);
				if ((xDir < 0 && facingRight) || (xDir > 0 && !facingRight)) {
					ChangeDirection ();
				}
			}
		}


	}

	void ChangeDirection() {
		facingRight = !facingRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);
	}
		
}
