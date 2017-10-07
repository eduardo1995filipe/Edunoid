//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Brick : MonoBehaviour {
//
//	public GameObject powerUp;
//
//	void Start(){
//		
//	}
//
//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.name == "ball") {
//			GameObject powerUp = Instantiate (GameObject.FindWithTag ("speed_power_up"));
//			powerUp.transform.position = gameObject.transform.position;
////			powerUp.SetActive (true);
//			Destroy (gameObject);
//		}
//	}
//
//
//	void OnDestroy(){
//		//TODO: criar powerups aqui
//	}
//}
