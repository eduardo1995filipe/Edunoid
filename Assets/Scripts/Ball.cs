using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public float speed = 100;
	public int points = 0;

	public Text pointsText;

	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
		pointsText = GameObject.FindGameObjectWithTag ("points").GetComponent<Text> ();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "racket") {
			GetComponent<Rigidbody2D> ().velocity = (new Vector2 (hitFactor (transform.position,
				col.transform.position,
				col.collider.bounds.size.x), 1).normalized) * speed;
		} else if (col.gameObject.tag == "end_life_wall" && gameObject != null) {
			gameObject.transform.position = new Vector2 (0, -106);
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
		} else if(col.gameObject.tag == "normal_brick") {
			points += 100;
			pointsText.text = points.ToString (); 
		}
	}

	void OnEnable(){
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
	}
		
	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
		return (ballPos.x - racketPos.x) / racketWidth;
	}
}
