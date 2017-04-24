using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour {

	public float moveSpeed; 		//variable so can set movespeed
	public bool moveRight;			// to make enmy move left or right

	public Transform wallCheck;		// to check if the enemy has hit a wall or not
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool notAtEdge;
	public Transform edgeCheck;

	public	Rigidbody2D rigibody2D;

	private float ySize;

	// Use this for initialization
	void Start () {
		rigibody2D = GetComponent<Rigidbody2D> ();

		ySize = transform.localScale.y;
	}

	// Update is called once per frame
	void Update () { // this looks after  the enemy movement checks its not hitting a wall or hitting an edge

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall); 	// checks to see if hitting a wall	
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);		// checks if at an edge

		if (hittingWall || !notAtEdge)
			moveRight = !moveRight;

		if (moveRight) {
			transform.localScale = new Vector3 (-ySize, transform.localScale.y, transform.localScale.z);	// moving right
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		
		} else {
			transform.localScale = new Vector3 (ySize, transform.localScale.y, transform.localScale.z);		// moving left
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);

		}

	} 

	void onTriggerEnter2D(Collider2D other){
		//creates the object 
		if (other.tag == "linuxBomb") {
			Destroy (other.gameObject);
			} 	/*		*/
	}
}
