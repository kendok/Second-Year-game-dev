using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public string mainGameScene; // making a variable that can drag which scene we want to load
	public string instructions;



	public void StartGame()
	{
		SceneManager.LoadScene (mainGameScene); 
	/*	if ( Input.GetKeyDown (KeyCode.Joystick1Button9)) {			// attempt to make the game start using start on snes 
			SceneManager.LoadScene (mainGameScene); 
		} */
	}
	public void QuitGame()
	{
		Application.Quit ();
	}public void Instructions()
	{
		SceneManager.LoadScene (instructions); 	
	}

	public void RestartGame()
	{
		SceneManager.LoadScene (mainGameScene);
	}
}
