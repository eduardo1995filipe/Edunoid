using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallCollisionManager{

	private static BallCollisionManager INSTANCE = new BallCollisionManager();

	private static readonly int[] BORDER_BRICKS_LEFT = { 1, 9, 17, 25, 33, 41, 49, 57, 65, 73, 81, 89 };
	private static readonly int[] BORDER_BRICKS_RIGHT = { 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 96 };
	private static readonly int[] TOP_BRICKS_TOP_LINE = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	private static readonly int[] TOP_BRICKS_MID_LINE = { 33, 34, 35, 36, 37, 38, 39, 40 };
	private static readonly int[] TOP_BRICKS_BOTTOM_LINE = { 65, 66, 67, 68, 69, 70, 71, 72 };

	private System.Random rand;

//	private static int TOTAL_BRICKS = 96;

	public enum ColorState
	{
		NEUTRAL = 1, RED = 2, BLUE = 3, GREEN = 4, YELLOW = 5
	};

	public enum BrickState
	{
		GOOD = 1, SEMI_BROKEN = 2, BROKEN = 3
	};

	public enum BallDensity
	{
		SOFT = 1, NORMAL = 2, HARD = 3
	}; 

	private BallCollisionManager()
	{
		rand = new System.Random();
	}

	public static BallCollisionManager getInstance()
	{
		return (INSTANCE != null) ? INSTANCE : new BallCollisionManager();
	} 

	public List<GameObject> getAdjacentBricks(int brickNum)
	{

		List<GameObject> brickList = new List<GameObject> ();

		bool isLeft, isRight;
		isLeft = isRight = false;

		foreach (int num in BORDER_BRICKS_LEFT)
			if (num == brickNum) 
			{
				isLeft = true;
			}
		foreach (int num in BORDER_BRICKS_RIGHT)
			if (num == brickNum) 
			{
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
		else if (isLeft) 
		{
			brickList.Add (getBrickByNumber (brickNum + 1));
			brickList.Add (getBrickByNumber (brickNum - 8));
		} 
		else if (isRight) 
		{
			brickList.Add (getBrickByNumber (brickNum - 1));
			brickList.Add (getBrickByNumber (brickNum - 8));
		} 
		else if (isTop) 
		{
			brickList.Add (getBrickByNumber (brickNum - 1));
			brickList.Add (getBrickByNumber (brickNum + 1));
		} 
		else
		{
			brickList.Add (getBrickByNumber (brickNum - 1));
			brickList.Add (getBrickByNumber (brickNum + 1));
			brickList.Add (getBrickByNumber (brickNum - 8));
		}
		return brickList;
	}
		
	private GameObject getBrickByNumber(int num)
	{
		GameObject[] brickArray = GameObject.FindGameObjectsWithTag ("normal_brick");
		foreach (GameObject brick in brickArray)
			if (brick.GetComponent<Brick> ().number == num)
				return brick;
		return null; //NULL VALUE DANGER!!!!
	}
		
	public int getRand(int min, int max)
	{
		return rand.Next (min, max);
	}

	public void changeBallColor(GameObject ball, ColorState state, BallDensity ballState)
	{
		
		int num = (ballState == BallDensity.NORMAL) ? 2 : ((ballState == BallDensity.HARD) ? 4 : 1);
		
		if(ball.tag == "ball")
		{
			Sprite sprite = Resources.Load<Sprite> ("Sprites/ball/Neutral/neutral_ball_" + num.ToString());
			switch(state)
			{
				case ColorState.NEUTRAL:
					break;
				case ColorState.RED:
					sprite = Resources.Load<Sprite> ("Sprites/ball/Red/red_ball_"  + num.ToString());
					break;
				case ColorState.BLUE:
					sprite = Resources.Load<Sprite> ("Sprites/ball/Blue/blue_ball_"  + num.ToString());
					break;
				case ColorState.GREEN:
					sprite = Resources.Load<Sprite> ("Sprites/ball/Green/green_ball_"  + num.ToString());
					break;
				case ColorState.YELLOW:
					sprite = Resources.Load<Sprite> ("Sprites/ball/Yellow/yellow_ball_"  + num.ToString());
					break;
				default:
					break;
				}
			ball.GetComponent<SpriteRenderer> ().sprite = sprite;
		}
	}
		
	public ColorState getRandomColor()
	{
		ColorState[] values = { ColorState.GREEN, ColorState.BLUE, ColorState.RED, ColorState.YELLOW, ColorState.NEUTRAL };
		return values [getRand (0, values.Length)]; // it's not lenght - 1 because the limit doens't count
	}
}
