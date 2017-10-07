using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillerWall : MonoBehaviour {

	public int numLivesLeft = 3;

	public Text livesLeftText;
	public GameObject racket;

	void Start(){
		livesLeftText = GameObject.FindGameObjectWithTag ("livesLeft").GetComponent<Text> ();
		racket = GameObject.FindGameObjectWithTag ("racket");
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "ball"){
			if ((numLivesLeft--) > 0) {
				livesLeftText.text = numLivesLeft.ToString ();
			} 
			else
				Destroy (col.gameObject);
			racket.transform.position = new Vector2 (0, -117);
		}
	}
}
