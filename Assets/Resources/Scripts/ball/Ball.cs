using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour 
{

	private const int POINT_POWER_UP_BLOCK_LIMIT = 10; //point powerup block limit
	private const int DEFAULT_POINT_GAIN = 100;
	private const int DEFAULT_SPEED = 100;
	BallCollisionManager bcm = BallCollisionManager.getInstance();

	public float speed = DEFAULT_SPEED;
	public int pointGain = DEFAULT_POINT_GAIN;
	public bool onPointPowerUp = false;
	private int pointPowerUpIterator = 0; //iterator, at 10 blocks hit the point gain returns to normal
	public int points = 0;
	public Vector2 dir = Vector2.up;
	public BallCollisionManager.BallDensity ballState = BallCollisionManager.BallDensity.NORMAL;
	public BallCollisionManager.ColorState ballColorState = BallCollisionManager.ColorState.NEUTRAL;

	public Text pointsText;

	void Start () 
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
		pointsText = GameObject.FindGameObjectWithTag ("points").GetComponent<Text> ();
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.name == "racket") 
		{
			GetComponent<Rigidbody2D> ().velocity = (new Vector2 (hitFactor (transform.position,
				col.transform.position,
				col.collider.bounds.size.x), 1).normalized) * speed;
		} 
		else if (col.gameObject.tag == "end_life_wall" && gameObject != null) 
		{
			gameObject.transform.position = new Vector2 (0, -106);
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.up * (speed = DEFAULT_SPEED);
			ballState = BallCollisionManager.BallDensity.NORMAL;
			ballColorState = BallCollisionManager.ColorState.NEUTRAL;
			GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/ball/Neutral/neutral_ball_2");
		} 
		else if(col.gameObject.tag == "normal_brick") 
		{
			if(pointPowerUpIterator < POINT_POWER_UP_BLOCK_LIMIT)
			{
				points += pointGain;
				pointsText.text = points.ToString ();
				++pointPowerUpIterator; 
			}
			else
			{
				pointGain = DEFAULT_POINT_GAIN;
				pointPowerUpIterator = 0;
			}
		} 
		else if(col.gameObject.tag == "multi_color_brick") 
		{

			//TODO: add ball density to ball of different color
			StartCoroutine(colorPowerUp());
		}
	}

	void OnEnable()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * (speed = 100);
	}
		
	

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) 
	{
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	public void updateVelocity(float newSpeed)
	{
		if (this.speed != 0) 
		{
			GetComponent<Rigidbody2D> ().velocity = (GetComponent<Rigidbody2D> ().velocity * newSpeed) / this.speed; 
			this.speed = newSpeed;
		}
	}

	IEnumerator colorPowerUp()
	{
		//TODO: Random Variable "Color Blocks"
		ballColorState = bcm.getRandomColor();
		bcm.changeBallColor (gameObject, ballColorState, ballState);
		yield return new WaitForSeconds (6);
		ballColorState = BallCollisionManager.ColorState.NEUTRAL;
		bcm.changeBallColor (gameObject, BallCollisionManager.ColorState.NEUTRAL, ballState);
	}
}
