using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public GameObject objParent;
	public SpriteRenderer objSprite;

	// Use this for initialization
	void Start () {
		objSprite = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		objParent = GameObject.Find ("Student");
		this.transform.parent = objParent.transform;
		this.transform.position = objParent.transform.position;
		objSprite.flipX = true;
	}
}
