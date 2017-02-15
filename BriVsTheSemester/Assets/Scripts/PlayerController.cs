using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	// player attributes
	public Rigidbody2D player;
	public float speed;
	private Vector3 move;
	private SpriteRenderer playerSprite;

	// UI components & AudioSources
	public AudioSource ouchImpact;
	public Text scoreDisplay;
	public int score;
	public Image losePanel;
	public Text endText;
	public Text hitPoints;
	public int hits;

	// used to access background music
	private GameObject background;
	private FieldController field;

	// used to count frames, to be used to quit game upon win
	private int count;
	private int endCount;

	// Use this for initialization
	void Start () {
		// get access to background for background music access
		background = GameObject.Find("Background");
		field = background.GetComponent<FieldController>();

		// get player & instantiate
		player = GetComponent<Rigidbody2D> ();
		playerSprite = GetComponent<SpriteRenderer> ();
		transform.position = new Vector3 (-8.79f, 0.0f, 0.0f);

		// initialize score & hit points, disable Lose screen
		score = 0;
		scoreDisplay.text = "Score: " + score;
		hits = 5;
		hitPoints.text = "Hit Points: " + hits;
		losePanel.enabled = false;
		endText.enabled = false;

		// initialize count and endCount
		count = 0;
		endCount = 500;
	}
	
	// Update is called once per frame after everything else renders
	void FixedUpdate () {
		/* function controls player movement based on input axis, movement restricted to
		 * a specified set of boundaries, direction player is facing changed based on
		 * left/right arrow input */

		Vector3 move = new Vector3 (Mathf.Clamp(Input.GetAxis ("Horizontal"), -9.0f, 9.0f), Mathf.Clamp(Input.GetAxis ("Vertical"),-3.0f,3.0f), 0.0f);
		transform.position += move * speed * Time.deltaTime;

		if (transform.position.x <= -9.0f) {
			transform.position = new Vector3 (-9.0f, transform.position.y, 0.0f);
		} else if (transform.position.x >= 9.0f) {
			transform.position = new Vector3 (9.0f, transform.position.y, 0.0f);
		}
		if (transform.position.y <= -3.0f) {
			transform.position = new Vector3 (transform.position.x, -3.0f, 0.0f);
		} else if (transform.position.y >= 3.0f) {
			transform.position = new Vector3 (transform.position.x, 3.0f, 0.0f);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			playerSprite.flipX = true;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			playerSprite.flipX = false;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		/* if player is hit by a book, hit points available decreases, impact noise plays
		 * if hit points are greater than 0; if hit points reaches 0 Lose screen is enabled,
		 * background music stopped & game over music played before game quits */

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
