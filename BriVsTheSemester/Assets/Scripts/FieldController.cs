using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldController : MonoBehaviour {

	public Text hallDamage;
	public Image losePanel;
	public Text endText;
	private int damage;
	public AudioSource backgroundMusic;
	public AudioSource gameOverSound;
	private FlyingBookGenerator numWaves;
	private int count;
	private int endCount;

	// Use this for initialization
	void Start () {
		backgroundMusic.Play ();
		damage = 0;
		hallDamage.text = "Hallway Damage: " + damage;
		losePanel.enabled = false;
		endText.enabled = false;
		count = 1;
		endCount = 500;
	}

	// Update is called once per frame
	void Update () {
		count++;
		if (damage == 5) {
			losePanel.enabled = true;
			endText.enabled = true;
			backgroundMusic.Stop ();
			gameOverSound.Play ();
			if (count % endCount == 0) {
				Application.Quit ();
			}
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