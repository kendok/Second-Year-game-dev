using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {


	public LevelManager levelManager;


	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){	//checks to see if hero has walked through the checkpoint if it does loads last checkpoint walked through
		if (other.name == "Random_Nerd") 
		{
			levelManager.currentCheckpoint = gameObject;
		}


	}
}
