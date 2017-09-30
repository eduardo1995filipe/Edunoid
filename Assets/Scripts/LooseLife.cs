using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LooseLife : MonoBehaviour {

	public Rigidbody2D platform;
	public Rigidbody2D ball;
	public Rigidbody2D speedPowerUp;

	public Text lifeText;
	public int numLifes;

	// Use this for initialization
	void Start () {
		this.lifeText = GameObject.Find ("lifesNumberLabel").GetComponent<Text>();
		this.numLifes = 3;

		this.platform = GameObject.Find ("racket").GetComponent<Rigidbody2D>();
		this.ball = GameObject.Find ("ball").GetComponent<Rigidbody2D>();
		this.speedPowerUp = GameObject.Find ("speed_power_up").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col) {
		switch(col.gameObject.tag){
		case "ball":
			StartCoroutine (newlife(col));	
			break;
		case "speed_power_up":
			Destroy (col.gameObject); //for now its destroyed
			break;
		default:
			break;
		}
	}

	IEnumerator newlife(Collision2D col) {
		if (col.gameObject.tag == "ball" && numLifes > 0) {
			GameObject.Find ("ball").GetComponent<Renderer> ().enabled = false;
			lifeText.text = (--numLifes).ToString ();
			yield return new WaitForSeconds (1);
			platform.transform.position = new Vector2 (0, -100);
			ball.transform.position = new Vector2 (0, -85);
			GameObject.Find ("ball").GetComponent<Renderer> ().enabled = true;
		} else if (numLifes == 0) {
			Destroy (GameObject.Find ("ball"));
		} 
	}
}
