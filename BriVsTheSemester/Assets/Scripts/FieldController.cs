using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldController : MonoBehaviour {

	// UI Components & AudioSources
	public Text hallDamage;
	public Image losePanel;
	public Text endText;
	private int damage;
	public AudioSource backgroundMusic;
	public AudioSource gameOverSound;
	private FlyingBookGenerator numWaves;

	// used to count frames, to be used to quit game upon loss
	private int count;
	private int endCount;

	// Use this for initialization
	void Start () {
		/* start playing background music, disable Losing screen, initialize
		 * hallDamage text & damage count, set initial frame count & endCount */
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
		count++;	// increase frame count each frame
	}

	void OnTriggerEnter2D(Collider2D other) {
		/* function destroys flying book if it reaches the edge of the playing field,
		 * updates hallway damage. if hallDamage reaches 5, player loses, Lose screen
		 * enabled, background music stopped & play losing music before quitting */

		if (other.gameObject.CompareTag ("Books")) {
			other.GetComponent<AudioSource>().Play();
			damage++;
			hallDamage.text = "Hallway Damage: " + damage;
			Destroy (other.gameObject, other.GetComponent<AudioSource>().clip.length);
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
	}
}