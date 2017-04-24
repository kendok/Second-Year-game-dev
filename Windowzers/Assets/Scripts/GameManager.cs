using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public CountdownTimer countDownTimer; 	// sets a timer 
	public Text secondsText;				//sets text for timer

	private PauseMenu thePauseMenu;			// making a pause menu
	public int totalSeconds = 60;			//variable setting total seconds


	// Use this for initialization
	void Start () {
		countDownTimer = GetComponent<CountdownTimer> ();
 		countDownTimer.ResetTimer(totalSeconds);

		thePauseMenu = FindObjectOfType<PauseMenu> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (thePauseMenu.isPaused)		// atempting to pause the time if the pause menu is running 
			return;	/**/
		
		string msg = "Seconds left = " + countDownTimer.GetSecondsRemaining(0);		
		secondsText.text = msg;
		CheckGameOver ();		// checks to see if the game is over 
	}
	private void CheckGameOver()
	{
		if (countDownTimer.GetSecondsRemaining (0) < 1) {
			SceneManager.LoadScene("scene1_GameOver");
		}
	}
}
