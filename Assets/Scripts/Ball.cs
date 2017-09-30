using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public static float DEFAULT_BALL_SPEED = 100.0f;
	public static int BRICK_VALUE = 100;

	public int points;
	public Text pointsText;
	public float speed;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		this.pointsText = GameObject.Find ("pointNumberLabel").GetComponent<Text>();
		this.points = 0;
		this.speed = DEFAULT_BALL_SPEED;
		this.rb = GetComponent<Rigidbody2D> ();

		rb.velocity = Vector2.up * speed;
		Physics2D.IgnoreCollision (GameObject.FindGameObjectWithTag("speed_power_up").GetComponent<Collider2D>(), GetComponent<Collider2D>());

	}


	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth){
		return (ballPos.x - racketPos.x)/racketWidth;
	}

	void OnCollisionEnter2D(Collision2D col) {
    // Hit the Racket?
    if (col.gameObject.name == "racket") {
        // Calculate hit Factor
        float x=hitFactor(transform.position,
                          col.transform.position,
                          col.collider.bounds.size.x);

        // Calculate direction, set length to 1
        Vector2 dir = new Vector2(x, 1).normalized;

        // Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}
		else if(col.gameObject.tag == "brick"){
			this.pointsText.text = (points += BRICK_VALUE).ToString ();
		}
	}
}
