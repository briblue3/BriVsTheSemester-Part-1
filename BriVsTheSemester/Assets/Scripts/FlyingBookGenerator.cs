using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingBookGenerator : MonoBehaviour {

	public Rigidbody2D book;
	public int frameDelta;	// initially set to 250 in Unity
	private int counter;
	public Text waveText;
	public int wave;
	public Image winPanel;
	public Text winText;
	private int maxBooks;
	private FieldController field;
	public AudioSource winMusic;

	// Use this for initialization
	void Start () {
		counter = 1;
		wave = 0;
		waveText.text = "Wave: " + wave;
		winPanel.enabled = false;
		winText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter % frameDelta == 0) {
			wave++;
			waveText.text = "Wave: " + wave;
			if (wave < 3) {
				maxBooks = 3;
			} else if (wave < 7) {
				maxBooks = 5;
			} else if (wave <= 15) {
				maxBooks = 7;
			}
			if (wave <= 15) {
				for (int i = 0; i < Random.Range (1, maxBooks); i++) {
					// between 1 and maxBooks books are randomly generated for each wave
					Rigidbody2D bookClone = (Rigidbody2D)Instantiate (book, transform.position, transform.rotation);
				}
			} else if (wave == 16) {
				winPanel.enabled = true;
				winText.enabled = true;
				field.backgroundMusic.Stop ();
				winMusic.Play ();
				if (counter % (frameDelta * 2) == 0) {
					Application.Quit ();
				}
			}
		}
	}
}
