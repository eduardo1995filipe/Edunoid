//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class Ball : MonoBehaviour {
//
//	public static float DEFAULT_BALL_SPEED = 200.0f;
////	public static int DEFAULT_BRICK_PONTUATION_VALUE = 100;
////	public static int BRICK_PONTUATION_VALUE = 100;
////
////	public Text pointsText; 
//
//	public Vector2 dir;
////	public int points;
//	private float speed;
//			
//	void Start () {
////		this.dir = Vector2.up;
////		this.points = 0;
////		this.pointsText = GameObject.Find ("pointNumberLabel").GetComponent<Text>();
////		this.speed = DEFAULT_BALL_SPEED;
//		GetComponent<Rigidbody2D>().velocity = Vector2.up * DEFAULT_BALL_SPEED;
//	}
//
//
//	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth){
//		return (ballPos.x - racketPos.x)/racketWidth;
//	}
//
//	void OnCollisionEnter2D(Collision2D col) {
//		if(col.gameObject.tag == "racket"){
//			float x=hitFactor(transform.position,
//				col.transform.position,
//				col.collider.bounds.size.x); // Calculate hit Factor
//
//
//			Vector2 dir = new Vector2(x,1).normalized;
//			GetComponent<Rigidbody2D> ().velocity = dir * speed;
//			//			setDir(new Vector2(x, 1).normalized); // Calculate direction, set length to 1
////			setVelocity(speed); // Set Velocity with dir * speed
//
//		}
////			else if(col.gameObject.tag == "speed_power_up"){
////			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(),
////				GetComponent<Collider2D>());
////		}else if(col.gameObject.tag == "brick"){
////			pointsText.text = (points += BRICK_PONTUATION_VALUE).ToString ();
////		}
//	}
//		
////	private void setDir(Vector2 dir){
////		this.dir = dir;
////	}
//
////	private Vector2 getDir(){
////		return this.dir;
////	}
////
////	public float getSpeed(){
////		return this.speed;
////	}
////
////	public void setVelocity(float speed){
////		float oldSpeed = this.speed;
////		Vector2 oldVelocity = GetComponent<Rigidbody2D> ().velocity;
////		this.speed = speed;
////		if(oldSpeed != 0){
////			GetComponent<Rigidbody2D> ().velocity = (oldVelocity / oldSpeed) * this.speed;
////		}
////	}
//}