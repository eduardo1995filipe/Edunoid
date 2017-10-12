using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPowerUp : MonoBehaviour {

	private BallCollisionManager bcm = BallCollisionManager.getInstance();

	public GameObject ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag ("ball");
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "normal_brick" || 
			col.gameObject.tag == "solid_brick" ||
			col.gameObject.tag == "speed_power_up" ||
			col.gameObject.tag == "point_power_up" ||
			col.gameObject.tag == "resize_power_up" ||
			col.gameObject.tag == "density_power_up" ||
			col.gameObject.tag == "ball"){
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),GetComponent<Collider2D> ());
		}else if(col.gameObject.tag == "racket"){
			if (ball != null) 
				ball.GetComponent<Ball> ().pointGain = bcm.getRand(-500,501);
				Destroy (gameObject);
		}
	}
}
