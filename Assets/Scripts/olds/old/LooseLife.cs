//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEngine;
//using System;
//
//public class LooseLife : MonoBehaviour {
//
//	public int numLifes;
//	public System.Random rand;
//
//	// Use this for initialization
//	void Start () {
//		this.numLifes = 3;
//		this.rand = new System.Random ();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	}
//
//	void OnCollisionEnter2D(Collision2D col) {
//		if (col.gameObject.tag == "ball") {
//			GameObject newBall = Instantiate(col.gameObject);
//			Destroy (col.gameObject);
//			if (numLifes > 0) {
//				StartCoroutine (newLife (newBall));
//			} else {
//				Destroy (newBall);
//				GameObject.FindGameObjectWithTag ("racket").GetComponent<RacketMovement> ().enable (false);
//			}
//			GameObject.Find ("racket").GetComponent<Rigidbody2D> ().transform.position = new Vector2 (0, -180);
//		} else if (col.gameObject.tag == "speed_power_up") {
//			Destroy (col.gameObject); //for now its destroyed
//		}
//	}
//
//	IEnumerator newLife (GameObject ball){
//		ball.SetActive (false);
//		ball.tag = "ball";
//		ball.transform.position = new Vector2 (0, -135);
//		Ball.BRICK_PONTUATION_VALUE = Ball.DEFAULT_BRICK_PONTUATION_VALUE;
//		GameObject.Find ("lifesNumberLabel").GetComponent<Text> ().text = (--numLifes).ToString ();
//		yield return new WaitForSeconds (2);
//		ball.SetActive (true);
//		ball.GetComponent<Rigidbody2D> ().velocity = Vector2.up * Ball.DEFAULT_BALL_SPEED;
//	}
//}
