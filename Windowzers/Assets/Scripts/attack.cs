using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

	public float penguinSpeed;  // this is for how fast the penguin travels

	private Rigidbody2D theRB;
	private Player playa;

	private PlayerDisplay playerDisplay;

	public GameObject bomb_Effect;	// the explosion if hits enemy
	public GameObject enemyDeath_Effect;

	public AudioClip zombieDeath; // audio file for zombie dying

	public float rotationSpeed; // to make the penguin spin 

	public int damageToGive;

	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		playerDisplay = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerDisplay> ();
		playa = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		theRB.velocity = new Vector2 (penguinSpeed* transform.localScale.x, 1);  // this lets you fire left or right
		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;   // want to make the penguin spin a little when throw
	}



	void OnTriggerEnter2D(Collider2D other)
	{


		//creates the object 
		if (other.tag == "Enemy") 		//if it hits enemy
			{
				playa.score += 35;	// adds 20 to the score
				playerDisplay.UpdateScoreText (playa.score);	//updates the score

				AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
				audioSRC.clip = zombieDeath;
				audioSRC.Play ();

			Instantiate (enemyDeath_Effect, other.transform.position, other.transform.rotation);

				Destroy (other.gameObject);		// destroys the game object

			} 
		if (other.tag == "Enemy1") 		//if it hits enemy
		{
			playa.score += 45;	// adds 25 to the score
			playerDisplay.UpdateScoreText (playa.score);	//updates the score

			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);

			AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
			audioSRC.clip = zombieDeath;
			audioSRC.Play ();



			Instantiate (enemyDeath_Effect, other.transform.position, other.transform.rotation);

		//	Destroy (other.gameObject);		// destroys the game object the enemy health manager looks after this now

		} 	
		if (other.tag == "Boss") 		//if it hits enemy
		{
			playa.score += 150;	// adds 25 to the score
			playerDisplay.UpdateScoreText (playa.score);	//updates the score


			other.GetComponent<BossHealthManager> ().giveDamage (damageToGive);

			Instantiate (enemyDeath_Effect, other.transform.position, other.transform.rotation);
			AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
			audioSRC.clip = zombieDeath;
			audioSRC.Play ();

		} 	

		//	Destroy (other.gameObject);		// destroys the game object

		




		//	Instantiate (bomb_Effect, transform.position, transform.rotation); // this looks after animation when bomb hits object

			Destroy (gameObject);
	}
}
