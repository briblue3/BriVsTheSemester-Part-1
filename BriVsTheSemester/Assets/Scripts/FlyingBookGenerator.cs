using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBookGenerator : MonoBehaviour {

	public Rigidbody2D book;
	public int frameDelta;	// initially set to 250 in Unity
	private int counter;

	// Use this for initialization
	void Start () {
		counter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter % frameDelta == 0) {
			//for (int i = 0; i < Random.Range (1, 5); i++) {
				// between 1 and 5 books are randomly generated for each wave
				Rigidbody2D bookClone = (Rigidbody2D)Instantiate (book, transform.position, transform.rotation);
			//}
		}
	}
}
