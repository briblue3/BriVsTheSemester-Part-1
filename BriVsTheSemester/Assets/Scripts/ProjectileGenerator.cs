using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour {

		public GameObject projParent;
		public Rigidbody2D projectile;
	private SpriteRenderer projSprite;

		// Use this for initialization
		void Start () {
			Rigidbody2D projectileClone = (Rigidbody2D)Instantiate (projectile, transform.position, transform.rotation);
		projectileClone.transform.position = new Vector3 (-7.25f, 3.41f, 0.0f);	
		projParent = GameObject.Find ("Student");
			projectileClone.transform.parent = projParent.transform;
			projSprite = GetComponent<SpriteRenderer> ();
		}

		// Update is called once per frame
		void Update () {

		}
	}