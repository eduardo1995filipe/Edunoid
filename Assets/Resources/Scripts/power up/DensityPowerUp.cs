using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DensityPowerUp : MonoBehaviour {

	BallCollisionManager bcm = BallCollisionManager.getInstance();

	public GameObject ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag ("ball");
	}
	
	// Update is called once per frame
	void Update () {
		
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
			if (ball != null) {
				int num = bcm.getRand (0, 2);
				string path = "Sprites/ball/Neutral/neutral_ball_";

				BallCollisionManager.ColorState state = ball.GetComponent<Ball> ().ballColorState;

				if (state == BallCollisionManager.ColorState.RED)
					path = "Sprites/ball/Red/red_ball_";
				else if (state == BallCollisionManager.ColorState.BLUE)
					path = "Sprites/ball/Blue/blue_ball_";
				else if (state == BallCollisionManager.ColorState.GREEN)
					path = "Sprites/ball/Green/green_ball_";
				else if (state == BallCollisionManager.ColorState.YELLOW)
					path = "Sprites/ball/Yellow/yellow_ball_";
				
				if (num == 1) {
					ball.GetComponent<Ball> ().ballState = BallCollisionManager.BallDensity.HARD;
					ball.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path + "4");
					Destroy (gameObject);
				} else {
					ball.GetComponent<Ball> ().ballState = BallCollisionManager.BallDensity.SOFT;
					ball.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (path + "1");
					Destroy (gameObject);
				}
			}
		}
	}
}
