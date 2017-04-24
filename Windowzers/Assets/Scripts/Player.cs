using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	

	public AudioClip win31;
	public AudioClip deathSound;
	public AudioClip keySound;
	public AudioClip wowSound;
	public AudioClip johnSound;

	public int score = 0;
	public int lives = 3;

	private GameManager gameManager;
	private PlayerDisplay playerDisplay;

	public Text keyText;



	void Start(){
		gameManager = Camera.main.GetComponent<GameManager> ();

		playerDisplay = GetComponent<PlayerDisplay>();

		if (Application.loadedLevel == 2) {
	//	if (SceneManager.LoadScene("Level1")){
		//	Debug.Log("LVL1");
			//score = 0;									// this sets the score and lives to 0 if on lvl 1
			lives = 3;
		
			PlayerPrefs.SetInt ("Score", score); 		//this is to bring the score onto the next level 
			PlayerPrefs.SetInt ("Lifes", lives);		//this is to bring the lifes onto the next level
		} else {
			
			Debug.Log("your starting on another lvl");
			score = PlayerPrefs.GetInt ("Score");
			lives = PlayerPrefs.GetInt ("Lifes");
		}
		playerDisplay.UpdateScoreText(score);
		playerDisplay.UpdateLivesText(lives);
	}


	// if the player lose a life runs this method and does a check if there is no more lives to lose it brings to game over scene
	private void LoseLife(){
		lives--;


		AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
		audioSRC.clip = deathSound;
		audioSRC.Play ();




		if(lives <= 0){
			SceneManager.LoadScene("scene1_GameOver");
		}
	//	playerDisplay.UpdateScoreText(score);
		playerDisplay.UpdateLivesText(lives);
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.CompareTag("Point"))
		{
			
			score++;				//adds score to collecting a windoze logo
			playerDisplay.UpdateScoreText(score);		// updates the score


			gameManager.countDownTimer.ResetTimer( gameManager.countDownTimer.GetSecondsRemaining(5)); // add 5 seconds to time
			string msg = "Seconds left = " + gameManager.countDownTimer.GetTotalSeconds();
			gameManager.secondsText.text = msg;

			Destroy (hit.gameObject);		//destroys the object

			AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
			audioSRC.clip = win31;
			audioSRC.Play ();

		}
		if(hit.CompareTag("SuperPoint"))
		{

			score+=10500;				//adds score to collecting a windoze logo
			lives+= 5;
			playerDisplay.UpdateScoreText(score);		// updates the score
			playerDisplay.UpdateLivesText(lives);

			gameManager.countDownTimer.ResetTimer( gameManager.countDownTimer.GetSecondsRemaining(25)); // add 25 seconds to time
			string msg = "Seconds left = " + gameManager.countDownTimer.GetTotalSeconds();
			gameManager.secondsText.text = msg;

			Destroy (hit.gameObject);		//destroys the object

			AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
			audioSRC.clip = wowSound;
			audioSRC.Play ();

		}

		if(hit.CompareTag("SuperPoint2"))
		{

			score+=10500;				//adds score to collecting a windoze logo

			playerDisplay.UpdateScoreText(score);		// updates the score

			gameManager.countDownTimer.ResetTimer( gameManager.countDownTimer.GetSecondsRemaining(30)); // add 25 seconds to time
			string msg = "Seconds left = " + gameManager.countDownTimer.GetTotalSeconds();
			gameManager.secondsText.text = msg;

			Destroy (hit.gameObject);		//destroys the object

			AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
			audioSRC.clip = johnSound;
			audioSRC.Play ();

		}
		if (hit.CompareTag ("Fire")) {			//if player hits fire
			LoseLife ();
		}
		if (hit.CompareTag ("Enemy")) {			//if player gets hit by an enemy 
			LoseLife ();
		}
		if (hit.CompareTag ("Enemy1")) {			//if player gets hit by an enemy 
			LoseLife ();
		}
		if (hit.CompareTag ("Boss")) {			//if player gets hit by an enemy 
			LoseLife ();
		}
		if (hit.CompareTag ("key1")) {			//if player gets key  
		//	Debug.Log("You got a magical key");


			AudioSource audioSRC = GetComponent <AudioSource> (); 		//plays an audio file		
			audioSRC.clip = keySound;
			audioSRC.Play ();

			gameManager.countDownTimer.ResetTimer( gameManager.countDownTimer.GetSecondsRemaining(15));
			string msg = "Seconds left = " + gameManager.countDownTimer.GetTotalSeconds();
			gameManager.secondsText.text = msg;


			GameVariables.keyCount += 1;

			if (GameVariables.keyCount == 1) {
				keyText.text = "Key";
			}
			Destroy (hit.gameObject);
		}


	}
}
