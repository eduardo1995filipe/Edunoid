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
				racket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprites/racket/racket_normal");
				Destroy (racket.GetComponent<BoxCollider2D> ());
				racket.AddComponent<BoxCollider2D> ();
			}
			else
				Destroy (col.gameObject);
			racket.transform.position = new Vector2 (0, -117);
		} else 
			Destroy (col.gameObject);
	}
}
