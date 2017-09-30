using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag("speed_power_up").GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "ball")
			Destroy(gameObject);
	}
}
