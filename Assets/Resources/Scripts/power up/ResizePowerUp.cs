using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizePowerUp : MonoBehaviour {
	
	BallCollisionManager bcm = BallCollisionManager.getInstance();

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
			int num = bcm.getRand (1, 6);
			Sprite sprite;
			switch (num){
			case 1:
				sprite = Resources.Load<Sprite>("Sprites/racket/racket_micro");
				break;
			case 2:
				sprite = Resources.Load<Sprite>("Sprites/racket/racket_small");
				break;
			case 3:
				sprite = Resources.Load<Sprite>("Sprites/racket/racket_normal");
				break;
			case 4:
				sprite = Resources.Load<Sprite>("Sprites/racket/racket_large");
				break;
			case 5:
				sprite = Resources.Load<Sprite>("Sprites/racket/racket_largest");
				break;
			default:
				print ("UNKNOWN_ERROR_RESIZE_POWER_SWITCH_CASE");
				sprite = Resources.Load<Sprite>("Sprites/racket/racket_normal");
				break;
			}
			racket.GetComponent<SpriteRenderer> ().sprite = sprite;
			Destroy (racket.GetComponent<BoxCollider2D> ());
			racket.AddComponent<BoxCollider2D> ();
			Destroy (gameObject);
		}
	}
}
