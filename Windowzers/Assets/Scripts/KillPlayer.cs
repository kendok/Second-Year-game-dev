using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	// if the player dies he is then reloaded to the last checkpoint

	public LevelManager levelManager;


	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Random_Nerd") 
		{
			levelManager.RespawnPlayer ();
		}


	}
}
