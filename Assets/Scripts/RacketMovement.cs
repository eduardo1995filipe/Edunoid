using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

	//Movement speed
	public static float DEFAULT_BALL_SPEED = 100.0f;
	public float speed = 150;
	public Rigidbody2D ball;

	void Start(){
		this.ball = GameObject.Find ("ball").GetComponent<Rigidbody2D>();
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

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "speed_power_up"){
			generateBallSpeed (GameObject.Find("ball"));
			Destroy (col.gameObject);
		}
	}

	public void generateBallSpeed(GameObject obj){
		System.Random rand = new System.Random ();
		setBallSpeed (/*((float)rand.Next(50,250)*/200.0f, obj);
		StartCoroutine (estabilizeSpeed(obj));
	}

	IEnumerator estabilizeSpeed(GameObject obj) {
		yield return new WaitForSeconds (6);
		setBallSpeed (DEFAULT_BALL_SPEED, obj);	
	}

	private void setBallSpeed(float newSpeed, GameObject obj){
		obj.GetComponent<Ball> ().speed = newSpeed;
	}

}
