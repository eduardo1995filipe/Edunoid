using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "ball"){
			GameObject speedPowerUp = Instantiate(GameObject.FindGameObjectWithTag ("speed_power_up")) as GameObject;
			speedPowerUp.transform.position = gameObject.transform.position;
			Destroy(gameObject);
		}
	}
}
