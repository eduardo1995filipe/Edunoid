using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizePowerUp : MonoBehaviour {

	public GameObject racket;

	// Use this for initialization
	void Start () {
		racket = GameObject.FindGameObjectWithTag ("racket");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "normal_brick" || 
			col.gameObject.tag == "solid_brick" ||
			col.gameObject.tag == "speed_power_up" ||
			col.gameObject.tag == "point_power_up" ||
			col.gameObject.tag == "resize_power_up" ||
			col.gameObject.tag == "density_power_up" ||
			col.gameObject.tag == "ball"){
			Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (),GetComponent<Collider2D> ());
		}else if(col.gameObject.tag == "racket"){
			//TODO: mudar o tamanho da racket ate perder a vida
			racket.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Sprites/racket/racket_largest");
			Destroy (racket.GetComponent<BoxCollider2D> ());
			racket.AddComponent<BoxCollider2D> ();
			Destroy (gameObject);
		}
	}
}
