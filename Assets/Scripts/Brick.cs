using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

	private int PROB_SPEED = 50; // mudar

	private System.Random rand;

	// Use this for initialization
	void Start () {
		this.rand = new System.Random ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "ball") {
			if (rand.Next (0, 100) < PROB_SPEED/* a mudar*/) {
				GameObject powerUp = Instantiate(GameObject.FindWithTag("speed_power_up"));
				powerUp.SetActive (false);
				powerUp.GetComponent<Rigidbody2D>().transform.position = gameObject.transform.position;
				powerUp.SetActive (true);
				powerUp.GetComponent<Rigidbody2D> ().gravityScale = 3;
				Physics2D.IgnoreCollision (GameObject.FindWithTag("ball").GetComponent<Collider2D>(),powerUp.GetComponent<Collider2D>());
			}
			Destroy (gameObject);
		}if(col.gameObject.tag == "speed_power_up")
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
}
