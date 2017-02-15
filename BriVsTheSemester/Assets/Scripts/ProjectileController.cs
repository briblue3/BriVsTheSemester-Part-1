using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public GameObject objParent;	// parent object

	// projectile & prefab sources
	public SpriteRenderer objSprite;
	public Rigidbody2D projectile;
	public Rigidbody2D prefab;

	// UI Components will be accessed via player object & script, using these variables
	private GameObject thePlayer;
	private PlayerController playerScript;
	public AudioSource impact;

	// Use this for initialization
	void Start () {
		// initialize the sprite object & get the player object for UI components
		objSprite = GetComponent<SpriteRenderer> ();
		thePlayer = GameObject.Find("Student");
		playerScript = thePlayer.GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {
		/* if Space Bar is pressed, throw the projectile & deteach it from
		 * its parent object, clone the prefab for another projectile */
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (this.objParent.name == "Student") {
				projectile.velocity = new Vector2 (10.0f, 0.0f);
				this.transform.parent = null;
				clone ();
			}
		}
	}

	void OnMouseDown() {
		/* when projectile is clicked, attach to parent & have player "hold" it,
		 * projectile direction needs flipped to face proper direction */
		objParent = GameObject.Find ("Student");
		this.transform.parent = objParent.transform;
		this.transform.position = objParent.transform.position;
		objSprite.flipX = true;
	}

	void clone() {
		/* function creates another projectile */
		Rigidbody2D projectileClone = (Rigidbody2D) Instantiate (prefab, transform.position, transform.rotation);
		projectileClone.transform.position = new Vector3 (-7.25f, 3.41f, 0.0f);	
	}


	void OnTriggerEnter2D(Collider2D other) {
		/* if projectile collides with a book, play the impact sound, increase the score
		 * via the player's UI components, destroy book and projectile */
		if (other.gameObject.CompareTag ("Books")) {
			impact.Play ();
			playerScript.score++;
			playerScript.scoreDisplay.text = "Score: " + playerScript.score;
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
