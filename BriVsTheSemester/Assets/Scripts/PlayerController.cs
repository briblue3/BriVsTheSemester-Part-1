using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D player;
	public float speed;
	private Vector3 move;
	public AudioSource fallingSound;
	private SpriteRenderer playerSprite;
	public Text scoreDisplay;
	public Rigidbody2D proj;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		playerSprite = GetComponent<SpriteRenderer> ();
		transform.position = new Vector3 (-8.79f, 0.0f, 0.0f);
		scoreDisplay.text = "Score: 0";
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
		if (Input.GetKeyDown (KeyCode.Space)) {
			proj.velocity = new Vector2(10.0f,0.0f);
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
