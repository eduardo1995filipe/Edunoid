using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

	//Movement speed
	public float speed = 150;

	void Start(){
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.freezeRotation = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Get Horizontal Input
		float h = Input.GetAxisRaw("Horizontal");

		// Set Velocity (movement direction * speed)
		GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
	}
}
