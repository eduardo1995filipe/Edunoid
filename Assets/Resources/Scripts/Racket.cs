using System.Collections;
using UnityEngine;

public class Racket : MonoBehaviour {

	public float speed = 150;

	void FixedUpdate () {
		if (GameObject.FindGameObjectWithTag ("ball") != null) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.right * Input.GetAxisRaw ("Horizontal") * speed;
		}
	}
}
