using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour {

	public AudioSource fallingBook;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		// Debug.Log ("Collided");
		if (other.gameObject.CompareTag("Books")) {
			// destroy flying book if it reaches edge of playing field
			fallingBook.Play();
			Destroy(other.gameObject);
		}
	}
}