using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour {

	public float moveSpeed;		//speed of hero
	public float jumpForce;		//how high he can j,p
	private float moveVelocity;  //how fast he moved
	private Rigidbody2D myRigidbody;
	private bool doubleJumped;		//to enable hero to double jump

	public bool grounded; 		//to check if he is ground
	public LayerMask whatisGround;	//establishing what is ground

	private Collider2D myCollider;

	private Animator myAnimator;

	public GameObject linuxBomb; 		//to make penguin bomb
	public Transform throwPoint;		//setting where it comes from


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> (); // attachs animator to player
	}
	
	// Update is called once per frame
	void Update () {


		grounded = Physics2D.IsTouchingLayers (myCollider, whatisGround); //checks to see if the character is grounded or not
			
			
		if (grounded) doubleJumped = false;

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetMouseButtonDown (1)||Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button1) )  //if hero press up arrow left clicks hits W or space or A on controler he jumps
		{
			if (grounded) {

				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);

			}
		} //to allow for double jump 
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetMouseButtonDown (1)||Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.Space)||Input.GetKeyDown(KeyCode.Joystick1Button1) ) //if hero press up arrow left clicks hits W or space or A on controler he jumps
		{
			if (!grounded && !doubleJumped) {		//this checks if you arent ground and have not already double jump then allows hero to double jump

				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				doubleJumped = true; //to make sure it will only allow 2 jumps

			}
		}

		moveVelocity = 0f;
		if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)||Input.GetAxis("Horizontal")<-0.9)	//if hero press left key or A or uses directional pad on controler move left
		{
			moveVelocity = -moveSpeed;
		//	myRigidbody.velocity = new Vector2 (-moveSpeed, myRigidbody.velocity.y);
			transform.localScale = new Vector3 (-2, 2, 2);
		}
		if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)||Input.GetAxis("Horizontal")>0.9)	//if hero press right key or A or uses directional pad on controler move right
		{
			moveVelocity = moveSpeed;
		//	myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);  // had to change the way I did this as after adding a material to stop sticking on edges he slid around
			transform.localScale = new Vector3 (2, 2, 2);
		}
		if ( Input.GetMouseButtonDown (0)||Input.GetKeyDown(KeyCode.Joystick1Button2))	//if hero press left mouse down or press B on controler hero shoots a linux bomb
		{
			GameObject linuxClone = (GameObject)Instantiate(linuxBomb, throwPoint.position, throwPoint.rotation);	//instanciate new penguin attacks
			linuxClone.transform.localScale = transform.localScale;  //this helps with penguin to be shoot the other way
			myAnimator.SetTrigger("Attack");
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity , myRigidbody.velocity.y);
		myAnimator.SetFloat ("Speed", Mathf.Abs(myRigidbody.velocity.x));
		myAnimator.SetBool ("Grounded", grounded);

	}
}
