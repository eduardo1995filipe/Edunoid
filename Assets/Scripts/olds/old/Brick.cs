//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class Brick : MonoBehaviour {
//
//	private int PROB_SPEED_POWER_UP = 100; // mudar
//	private int PROB_POINT_POWER_UP = 200; // mudar
//
//	private System.Random rand;
//
//	// Use this for initialization
//	void Start () {
//		this.rand = new System.Random ();
//	}
//	
//	// Update is called once per frame
//	void FixedUpdate () {
//		
//	}
//
//	void OnCollisionEnter2D(Collision2D col) {
//		if (col.gameObject.tag == "ball") {
//			int randNum = rand.Next (0, 1000);
//			if (/*randNum < PROB_SPEED_POWER_UP*/true) {
//				GameObject speedPowerUp = Instantiate(GameObject.FindWithTag("speed_power_up"));
//				SpeedPowerUp script = GameObject.FindWithTag ("speed_power_up").GetComponent<SpeedPowerUp> ();
//				speedPowerUp.SetActive (false);
//				speedPowerUp.GetComponent<Rigidbody2D>().transform.position = gameObject.transform.position;
//				speedPowerUp.GetComponent<Rigidbody2D> ().gravityScale = 3;
//				Physics2D.IgnoreCollision (GameObject.FindWithTag("ball").GetComponent<Collider2D>(),speedPowerUp.GetComponent<Collider2D>());
//				Physics2D.IgnoreCollision (GameObject.FindWithTag("speed_power_up").GetComponent<Collider2D>(),speedPowerUp.GetComponent<Collider2D>());
//				//				Physics2D.IgnoreCollision (GameObject.FindWithTag("point_power_up").GetComponent<Collider2D>(),GetComponent<Collider2D>());
//				speedPowerUp.SetActive (true);
//			}
////			else if(randNum < PROB_POINT_POWER_UP){
////				GameObject pointPowerUp = Instantiate(GameObject.FindWithTag("point_power_up"));
////				pointPowerUp.SetActive (false);
////				pointPowerUp.GetComponent<Rigidbody2D>().transform.position = gameObject.transform.position;
////				pointPowerUp.SetActive (true);
////				pointPowerUp.GetComponent<Rigidbody2D> ().gravityScale = 3;
////				Physics2D.IgnoreCollision (GameObject.FindWithTag("ball").GetComponent<Collider2D>(),pointPowerUp.GetComponent<Collider2D>());
////				Physics2D.IgnoreCollision (GameObject.FindWithTag("speed_power_up").GetComponent<Collider2D>(),pointPowerUp.GetComponent<Collider2D>());
////			}
//			Destroy (gameObject);
//		}if(col.gameObject.tag == "speed_power_up")
//			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
//	}
//}