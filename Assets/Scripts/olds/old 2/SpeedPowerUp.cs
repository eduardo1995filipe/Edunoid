//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class SpeedPowerUp : MonoBehaviour {
//
//	public System.Random rand = new System.Random ();
//
//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.name == "racket") {
//			Destroy (gameObject);
//		}else if(col.gameObject.tag == "wall_bottom"){
//			Destroy (gameObject);
//		}else if(col.gameObject.tag == "solid_brick" || col.gameObject.name == "ball" 
//			|| col.gameObject.tag == "normal_brick" || col.gameObject.tag == "speed_power_up"){
//			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());		
//		}
//	}
//}
