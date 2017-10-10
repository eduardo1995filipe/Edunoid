using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	BallCollisionManager bcm = BallCollisionManager.getInstance();

	public int number;
	public BallCollisionManager.BrickState brickState = BallCollisionManager.BrickState.GOOD;

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "ball"){
			if (col.gameObject.GetComponent<Ball> ().ballState == BallCollisionManager.BallDensity.NORMAL) {
//			GameObject speedPowerUp = Instantiate(GameObject.FindGameObjectWithTag ("speed_power_up")) as GameObject;
//			speedPowerUp.transform.position = gameObject.transform.position;
//			GameObject pointPowerUp = Instantiate(GameObject.FindGameObjectWithTag ("point_power_up")) as GameObject;
//			pointPowerUp.transform.position = gameObject.transform.position;
//			GameObject resizePowerUp = Instantiate(GameObject.FindGameObjectWithTag ("resize_power_up")) as GameObject;
//			resizePowerUp.transform.position = gameObject.transform.position;
				GameObject densityPowerUp = Instantiate (GameObject.FindGameObjectWithTag ("density_power_up")) as GameObject;
				densityPowerUp.transform.position = gameObject.transform.position;
				Destroy (gameObject);
			}else if(col.gameObject.GetComponent<Ball> ().ballState == BallCollisionManager.BallDensity.HARD){
				List<GameObject> brickList = bcm.getAdjacentBricks (number);
				if(brickList != null)
					foreach( GameObject brick in brickList)
						Destroy (brick);
				Destroy (gameObject);
			}
		}
	}
}
