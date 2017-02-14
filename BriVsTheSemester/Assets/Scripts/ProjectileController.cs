using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public GameObject objParent;
	public SpriteRenderer objSprite;
	public Rigidbody2D projectile;
	private Vector3 move;
	public int speed;
	public Rigidbody2D prefab;
	private GameObject thePlayer;
	private PlayerController playerScript;
	public AudioSource impact;

	// Use this for initialization
	void Start () {
		objSprite = GetComponent<SpriteRenderer> ();
		thePlayer = GameObject.Find("Student");
		playerScript = thePlayer.GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (this.objParent.name == "Student") {
				projectile.velocity = new Vector2 (10.0f, 0.0f);
				this.transform.parent = null;
				clone ();
			}
		}
	}

	void OnMouseDown() {
		objParent = GameObject.Find ("Student");
		this.transform.parent = objParent.transform;
		this.transform.position = objParent.transform.position;
		objSprite.flipX = true;
	}

	void clone() {
		Rigidbody2D projectileClone = (Rigidbody2D) Instantiate (prefab, transform.position, transform.rotation);
		projectileClone.transform.position = new Vector3 (-7.25f, 3.41f, 0.0f);	
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Books")) {
			impact.Play ();
			playerScript.score++;
			playerScript.scoreDisplay.text = "Score: " + playerScript.score;
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
