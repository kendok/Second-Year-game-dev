using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	
//	public string levelSelect;
//	public string mainMenu;

	public bool isPaused;		//bool to see if the game is paused or not
	public GameObject pauseMenuCanvas;		//brings the menu in 
	public string mainGameScene;


	void Update () {
		
		if (isPaused) {				//if in the pause menu it sets the pause menu to come in and stops the timer. if it is not paused the time continues
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}
		if (Input.GetKeyDown (KeyCode.Escape)||Input.GetKeyDown(KeyCode.Joystick1Button9)) 	// if a player hits escape or the start on the controler
		{
			isPaused = !isPaused;
		}
	}
	public void Resume()
	{
		isPaused = false;
	}
	public void Quit()
	{
		SceneManager.LoadScene (mainGameScene);
	}
}
