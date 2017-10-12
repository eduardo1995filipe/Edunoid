﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	BallCollisionManager bcm = BallCollisionManager.getInstance();

	private GameObject[] gameObjectArray = new GameObject[4];

	public int number;
	public BallCollisionManager.BrickState brickState = BallCollisionManager.BrickState.GOOD;

	void Start(){
		gameObjectArray [0] = GameObject.FindGameObjectWithTag ("speed_power_up");
		gameObjectArray [1] = GameObject.FindGameObjectWithTag ("point_power_up");
		gameObjectArray [2] = GameObject.FindGameObjectWithTag ("resize_power_up");
		gameObjectArray [3] = GameObject.FindGameObjectWithTag ("density_power_up");
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "ball"){
			if (col.gameObject.GetComponent<Ball> ().ballState == BallCollisionManager.BallDensity.NORMAL) {
				breakBrick ();
			}else if(col.gameObject.GetComponent<Ball> ().ballState == BallCollisionManager.BallDensity.HARD){
				breakAdjacentBricks ();
			}else if(col.gameObject.GetComponent<Ball> ().ballState == BallCollisionManager.BallDensity.SOFT){
				if (brickState == BallCollisionManager.BrickState.GOOD) {
					brickState = BallCollisionManager.BrickState.SEMI_BROKEN;
					string tileTextureName = GetComponent<SpriteRenderer>().sprite.texture.name;
					GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprites/bricks/" + tileTextureName + "_broken");
				}
				else if (brickState == BallCollisionManager.BrickState.SEMI_BROKEN) {
					brickState = BallCollisionManager.BrickState.BROKEN;
					breakBrick();
				}
			}
		}
	}

	private void breakBrick(GameObject brick){
		if(brick.tag == "normal_brick"){
			int num = bcm.getRand (0,51);
		if (num < gameObjectArray.Length) {
			GameObject powerUp = Instantiate (gameObjectArray [num]) as GameObject;
			powerUp.transform.position = gameObject.transform.position;
		}
		Destroy(brick);
		}
	}

	private void breakBrick(){
		int num = bcm.getRand (0,10);
		if (num < gameObjectArray.Length) {
			GameObject powerUp = Instantiate (gameObjectArray [num]) as GameObject;
			powerUp.transform.position = gameObject.transform.position;
		}
		Destroy(gameObject);
	}


	private void breakAdjacentBricks(){
		List<GameObject> brickList = bcm.getAdjacentBricks (number);
		if (brickList != null)
			foreach (GameObject brick in brickList)
				if(brick != null)
					breakBrick (brick);
		breakBrick ();
	}
}
