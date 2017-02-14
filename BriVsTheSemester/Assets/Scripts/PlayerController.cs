using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D player;
	public float speed;
	private Vector3 move;
	private SpriteRenderer playerSprite;
	public AudioSource ouchImpact;

	public Text scoreDisplay;
	public int score;
	private GameObject background;
	private FieldController field;
	public Image losePanel;
	public Text endText;
	public Text hitPoints;
	public int hits;
	private int count;
	private int endCount;

	// Use this for initialization
	void Start () {
		background = GameObject.Find("Background");
		field = background.GetComponent<FieldController>();
		player = GetComponent<Rigidbody2D> ();
		playerSprite = GetComponent<SpriteRenderer> ();
		transform.position = new Vector3 (-8.79f, 0.0f, 0.0f);
		score = 0;
		scoreDisplay.text = "Score: " + score;
		hits = 5;
		hitPoints.text = "Hit Points: " + hits;
		losePanel.enabled = false;
		endText.enabled = false;
		count = 0;
		endCount = 500;
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
			hits = hits - 1;
			hitPoints.text = "Hit Points: " + hits;
			Destroy (other.gameObject);
			if (hits > 0) {
				ouchImpact.Play ();
			} else if (hits == 0) {
				losePanel.enabled = true;
				endText.enabled = true;
				field.backgroundMusic.Stop ();
				field.gameOverSound.Play ();
				if (count % endCount == 0) {
					Application.Quit ();
				}
			}
		}
	}
}
