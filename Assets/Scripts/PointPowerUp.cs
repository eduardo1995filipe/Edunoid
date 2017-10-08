using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPowerUp : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag ("ball");
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "normal_brick" || 
			col.gameObject.tag == "solid_brick" ||
			col.gameObject.tag == "speed_power_up" ||
			col.gameObject.tag == "ball" ||
			col.gameObject.tag == "point_power_up" ){
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),GetComponent<Collider2D> ());
		}else if(col.gameObject.tag == "racket"){
			ball.GetComponent<Ball> ().pointGain = 300;
			Destroy (gameObject);
			//TODO: programar aqui a funcionalidade do power up
		}
	}
}
