using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public GameObject objParent;
	public SpriteRenderer objSprite;
	public Rigidbody2D projectile;
	public Rigidbody2D projectileClone;
	private Vector3 move;
	public int speed;
	public float Force;

	// Use this for initialization
	void Start () {
		objSprite = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 move = new Vector3 (transform.position.x, transform.position.y, 0.0f);
			transform.position -= move * speed * Time.deltaTime;
		}
	}

	void OnMouseDown() {
		objParent = GameObject.Find ("Student");
		this.transform.parent = objParent.transform;
		this.transform.position = objParent.transform.position;
		objSprite.flipX = true;
		clone ();
	}

	void clone() {
		projectileClone = (Rigidbody2D)Instantiate (projectile, transform.position, transform.rotation);
		projectileClone.transform.position = new Vector3 (-7.25f, 3.41f, 0.0f);	
	}
//
//	void throwProj(){
//		projectile.AddForce (new Vector2(speed * Time.deltaTime, 0.0f), Force);
//	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Books")) {
			Destroy (other);
		}
	}
}
