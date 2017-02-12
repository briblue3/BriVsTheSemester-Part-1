using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D player;
	public float speed;
	private Vector3 move;
	public AudioSource fallingSound;
	private SpriteRenderer playerSprite;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		playerSprite = GetComponent<SpriteRenderer> ();
		transform.position = new Vector3 (-8.79f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame after everything else renders
	void FixedUpdate () {
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
		transform.position += move * speed * Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			playerSprite.flipX = true;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			playerSprite.flipX = false;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		// Debug.Log ("Collided");
		if (other.gameObject.CompareTag ("Books")) {
			fallingSound.Play ();
			Destroy (other.gameObject);
		}
	}
}
