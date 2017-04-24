using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed; 		//variable so can set movespeed
	public bool moveRight;			// to make enmy move left or right

	public Transform wallCheck;		// to check if the enemy has hit a wall or not
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool notAtEdge;
	public Transform edgeCheck;

	Rigidbody2D rigibody2D;

	// Use this for initialization
	void Start () {
		if (!moveRight)
			moveSpeed = -moveSpeed;
		
		rigibody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () { // this looks after  the enemy movement checks its not hitting a wall or hitting an edge

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall); 		
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge)  // if hitting a wall and not at edge
			Flip();

		Move();
	}

	void Move() {
		rigibody2D.velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y); 
	}

	/* 
     * Flip sprite
     */
	public void Flip ()
	{
		moveRight = !moveRight;
		moveSpeed = -moveSpeed;

		transform.localScale = FlipVector (transform.localScale);
	}

	public Vector3 FlipVector (Vector3 scale)
	{
		scale.x *= -1;
		return scale;
	}

	void onTriggerEnter2D(Collider2D other){
		//creates the object 
		if (other.tag == "linuxBomb") {
			Destroy (other.gameObject);
		} 	/*		*/
	}
}
