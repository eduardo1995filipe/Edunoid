//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class Ball : MonoBehaviour {
//
//
//	public int numLives = 3;
//	public float speed = 100.0f;
//
//	void Start () {
//		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed; 
//	}
//
//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.tag == "racket") {
//			float x = hitFactor (transform.position, col.transform.position, col.collider.bounds.size.x);			
//			Vector2 dir = new Vector2 (x, 1).normalized;
//			GetComponent<Rigidbody2D> ().velocity = dir * speed;
//		} else if (col.gameObject.tag == "normal_brick") {
//			
//		} else if (col.gameObject.tag == "speed_power_up") {
//			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),GetComponent<Collider2D>());
//		} else if(col.gameObject.tag == "end_life_wall"){
//			//TODO: lifes functionality
//			gameObject.SetActive(false);
//			GameObject ball = Instantiate(gameObject);
//			Destroy (gameObject);
//			ball.SetActive (false);
//			StartCoroutine (respawn(ball));
//			ball.SetActive (true);
//			ball.GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
//		} 
//	}
//
//	IEnumerator respawn (GameObject obj){
//		GameObject.FindWithTag("racket").transform.position = new Vector2 (0, -117);
//		yield return new WaitForSeconds (2);
//		obj.transform.position = new Vector2 (0, -106);
//	}
//
//	private float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketWidth){
//		return (ballPosition.x - racketPosition.x) / racketWidth;
//	}
//
//	void OnEnable(){
//		this.speed = 100;
//		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
//	}
//
//	void OnDestroy(){
//		
//	}
//}