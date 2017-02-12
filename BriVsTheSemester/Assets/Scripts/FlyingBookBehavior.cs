using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBookBehavior : MonoBehaviour {
	private float speed;
	private float posX;
	private float posY;

	// Use this for initialization
	void Start () {
		speed = Random.Range (0.01f, 0.07f);	// random speed between 0.01 and 0.07
		posX = 10.5f;	// will generate off screen right
		posY = Random.Range (-4.3f, 2.5f);	// random Y axis position
		transform.position = new Vector3(posX, posY, 0.0f);		// initial position
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x - speed, posY,0.0f);
	}
}