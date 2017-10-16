using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	BallCollisionManager bcm = BallCollisionManager.getInstance();

	public float speed = 100;
	public int pointGain = 100;
	public int points = 0;
	public Vector2 dir = Vector2.up;
	public BallCollisionManager.BallDensity ballState = BallCollisionManager.BallDensity.NORMAL;
	public BallCollisionManager.ColorState ballColorState = BallCollisionManager.ColorState.NEUTRAL;

	public Text pointsText;

	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
		pointsText = GameObject.FindGameObjectWithTag ("points").GetComponent<Text> ();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "racket") {
			GetComponent<Rigidbody2D> ().velocity = (new Vector2 (hitFactor (transform.position,
				col.transform.position,
				col.collider.bounds.size.x), 1).normalized) * speed;
		} else if (col.gameObject.tag == "end_life_wall" && gameObject != null) {
			gameObject.transform.position = new Vector2 (0, -106);
			gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.up * (speed = 100);
			ballState = BallCollisionManager.BallDensity.NORMAL;
			ballColorState = BallCollisionManager.ColorState.NEUTRAL;
			GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/ball/Neutral/neutral_ball_2");
		} else if(col.gameObject.tag == "normal_brick") {
			points += pointGain;
			pointsText.text = points.ToString (); 
		} else if(col.gameObject.tag == "multi_color_brick") {

			//TODO: add ball density to ball of different color
			StartCoroutine(colorPowerUp());
		}
	}

	void OnEnable(){
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * (speed = 100);
	}
		
	

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	public void updateVelocity(float newSpeed){
		if (this.speed != 0) {
			GetComponent<Rigidbody2D> ().velocity = (GetComponent<Rigidbody2D> ().velocity * newSpeed) / this.speed; 
			this.speed = newSpeed;
		}
	}

	IEnumerator colorPowerUp(){
		ballColorState = bcm.getRandomColor();
		bcm.changeBallColor (gameObject, ballColorState, ballState);
		yield return new WaitForSeconds (6);
		ballColorState = BallCollisionManager.ColorState.NEUTRAL;
		bcm.changeBallColor (gameObject, BallCollisionManager.ColorState.NEUTRAL, ballState);
	}
}
