//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class PointPowerUp : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//
//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.name == "racket") 
//			boostPoints ();
//		else if(col.gameObject.name == "wall_h")
//			Destroy (gameObject);
//		else if(col.gameObject.tag == "speed_power_up" || col.gameObject.tag == "ball" ||
//			col.gameObject.tag == "brick" || col.gameObject.tag == "point_power_up")
//			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
//	}
//
//	private void boostPoints(){
//		Ball.BRICK_PONTUATION_VALUE += 100;
//			Destroy (gameObject);
//	}
//}
