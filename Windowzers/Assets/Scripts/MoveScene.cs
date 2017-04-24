using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MoveScene : MonoBehaviour {

	public Image black; 
	public Animator anim;
	Player scoreScript;
	public AudioClip noKeySound;

	public string loadLevel; // to make it visible within the inspector 

	void Start(){
		scoreScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

	}


	void OnTriggerEnter2D(Collider2D other)		// if the player colides with object  
	{
		if (other.CompareTag ("Player") && GameVariables.keyCount>0 ) //&& Player.key1obtained == true
		{
			GameVariables.keyCount--;		
			PlayerPrefs.SetInt("Score", scoreScript.score); 		// brings the score 
			PlayerPrefs.SetInt("Lifes", scoreScript.lives);			// and the life over to the next level
			StartCoroutine(Fading());								// begins the fade between scenes
		}
		 else{ // if dont have any key play this sound                   if (other.CompareTag ("Player") && GameVariables.keyCount <= 0)

			AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
			audioSRC.clip = noKeySound;
			audioSRC.Play ();

		} /* */

	}
	IEnumerator Fading()
	{
		anim.SetBool ("Fade", true);				 //fades to black
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene (loadLevel);
	} /*	*/
}