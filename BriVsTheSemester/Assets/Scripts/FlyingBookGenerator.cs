using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingBookGenerator : MonoBehaviour {

	public Rigidbody2D book;	// 'zombie'

	// used to space out the waves of flying books
	public int frameDelta;
	private int counter;

	// UI Components & AudioSources
	public Text waveText;
	public int wave;
	public Image winPanel;
	public Text winText;
	private int maxBooks;
	public AudioSource winMusic;

	// used to access the background music from the Field Controller Script
	private GameObject field;
	private FieldController fieldScript;

	// Use this for initialization
	void Start () {
		/* Set the access to the background, to use for background music access later.
		 * Set frame counter to 1, set initial waveText, disable the components that
		 * form the Winning screen. */
		field = GameObject.Find ("Background");
		fieldScript = field.GetComponent<FieldController> ();
		counter = 1;
		wave = 0;
		waveText.text = "Wave: " + wave;
		winPanel.enabled = false;
		winText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;	// increase counter each frame
		if (counter % frameDelta == 0) {
			/* on every frameDelta'th frame, increase wave number & update waveText,
			 * determine maxBooks based on current wave of flying books */
			wave++;
			waveText.text = "Wave: " + wave;
			if (wave < 3) {
				maxBooks = 3;
			} else if (wave < 7) {
				maxBooks = 5;
			} else if (wave <= 15) {
				maxBooks = 7;
			}
			genBooks (wave, maxBooks);	// call book generator
		}
	}

	void genBooks (int wave, int maxBooks) {
		/* function generates books, if all waves passed, display Winning screen,
		 * disable background music & play winning music before quitting game */
		if (wave <= 15) {
			for (int i = 0; i < Random.Range (1, maxBooks); i++) {
				// between 1 and maxBooks books are randomly generated for each wave
				Rigidbody2D bookClone = (Rigidbody2D)Instantiate (book, transform.position, transform.rotation);
			}
		} else {
			winMusic.Play ();
			winPanel.enabled = true;
			winText.enabled = true;
			fieldScript.backgroundMusic.Stop ();
			if (counter % (frameDelta * 2) == 0) {
				Application.Quit ();
			}
		}
	}
}
