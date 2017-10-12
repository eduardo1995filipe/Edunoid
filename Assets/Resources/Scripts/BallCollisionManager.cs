using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionManager{

	private static BallCollisionManager INSTANCE = new BallCollisionManager();

	private static int[] BORDER_BRICKS_LEFT = { 1, 9, 17, 25, 33, 41, 49, 57, 65, 73, 81, 89 };
	private static int[] BORDER_BRICKS_RIGHT = { 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 96 };
	private static int[] TOP_BRICKS_TOP_LINE = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	private static int[] TOP_BRICKS_MID_LINE = { 33, 34, 35, 36, 37, 38, 39, 40 };
	private static int[] TOP_BRICKS_BOTTOM_LINE = { 65, 66, 67, 68, 69, 70, 71, 72 };

	private System.Random rand;

//	private static int TOTAL_BRICKS = 96;

	public enum BrickState
	{
		GOOD = 1, SEMI_BROKEN = 2, BROKEN = 3
	};

	public enum BallDensity
	{
		SOFT = 1, NORMAL = 2, HARD = 3
	}; 

	private BallCollisionManager(){
		rand = new System.Random();
	}

	public static BallCollisionManager getInstance(){
		return (INSTANCE != null) ? INSTANCE : new BallCollisionManager();
	} 

	public List<GameObject> getAdjacentBricks(int brickNum){

		List<GameObject> brickList = new List<GameObject> ();

		bool isLeft, isRight;
		isLeft = isRight = false;

		foreach (int num in BORDER_BRICKS_LEFT)
			if (num == brickNum) {
				isLeft = true;
			}
		foreach (int num in BORDER_BRICKS_RIGHT)
			if (num == brickNum) {
				isRight = true;
			}
		
		bool isTop = 
			(brickNum <= TOP_BRICKS_TOP_LINE [TOP_BRICKS_TOP_LINE.Length - 1]) ||
			((brickNum >= TOP_BRICKS_MID_LINE [0]) && (brickNum <= TOP_BRICKS_MID_LINE [TOP_BRICKS_MID_LINE.Length - 1])) ||
			((brickNum >= TOP_BRICKS_BOTTOM_LINE [0]) && (brickNum <= TOP_BRICKS_BOTTOM_LINE [TOP_BRICKS_BOTTOM_LINE.Length - 1]));

		//CAREFULL!!! NULL VALUES DANGER
		if (isLeft && isTop)
			brickList.Add (getBrickByNumber (brickNum + 1));
		else if (isRight && isTop)
			brickList.Add (getBrickByNumber (brickNum - 1));
		else if (isLeft) {
			brickList.Add (getBrickByNumber (brickNum + 1));
			brickList.Add (getBrickByNumber (brickNum - 8));
		} else if (isRight) {
			brickList.Add (getBrickByNumber (brickNum - 1));
			brickList.Add (getBrickByNumber (brickNum - 8));
		} else if (isTop) {
			brickList.Add (getBrickByNumber (brickNum - 1));
			brickList.Add (getBrickByNumber (brickNum + 1));
		} else{
			brickList.Add (getBrickByNumber (brickNum - 1));
			brickList.Add (getBrickByNumber (brickNum + 1));
			brickList.Add (getBrickByNumber (brickNum - 8));
		}
		return brickList;
	}
		
	private GameObject getBrickByNumber(int num){
		GameObject[] brickArray = GameObject.FindGameObjectsWithTag ("normal_brick");
		foreach (GameObject brick in brickArray)
			if (brick.GetComponent<Brick> ().number == num)
				return brick;
		return null; //NULL VALUE DANGER!!!!
	}
		
	public int getRand(int min, int max){
		return rand.Next (min, max);
	}

}
