using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "racket") 
			boostBall ();
		else if(col.gameObject.name == "wall_h")
			Destroy (gameObject);
		else if(col.gameObject.tag == "speed_power_up" || col.gameObject.tag == "ball" || col.gameObject.tag == "brick")
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}
		
	private void boostBall(){
		System.Random rand = new System.Random ();
		try{
			GameObject.FindWithTag ("ball").GetComponent<Ball> ().setVelocity (((float)rand.Next(50,250))); 
		}catch(NullReferenceException e){
			Console.WriteLine (e);
		}finally{
			Destroy (gameObject);
		}
	}
}
