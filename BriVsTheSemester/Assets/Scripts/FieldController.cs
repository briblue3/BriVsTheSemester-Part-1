using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldController : MonoBehaviour {

	public Text hallDamage;

	private int damage;

	// Use this for initialization
	void Start () {
		damage = 0;
		hallDamage.text = "Hallway Damage: " + damage;
	}

	// Update is called once per frame
	void Update () {
		if (damage == 5) {
			
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Debug.Log ("Collided");
		if (other.gameObject.CompareTag ("Books")) {
			// destroy flying book if it reaches edge of playing field
			other.GetComponent<AudioSource>().Play();
			damage++;
			hallDamage.text = "Hallway Damage: " + damage;
			Destroy (other.gameObject, other.GetComponent<AudioSource>().clip.length);
		}
	}
}