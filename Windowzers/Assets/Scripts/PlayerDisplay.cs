using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour {
	
	public Text scoreText;
	public Text livesText;
	public Player player;

	void Start()
	{
		player = GetComponent<Player> ();
	}


	public void UpdateScoreText(int newScore){
		string scoreMessage = "Score = " + newScore;
		scoreText.text = scoreMessage;
	}
	public void UpdateLivesText(int newLives){
		string livesMessage = "Lives = " + newLives;
		livesText.text = livesMessage;
	}


}
