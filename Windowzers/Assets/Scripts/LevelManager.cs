using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;


	private Player_Controler player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player_Controler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RespawnPlayer()
	{
		Debug.Log ("Fire HOT HOT HAWT ");
		player.transform.position = currentCheckpoint.transform.position;		// loads the last point the player has walked through
	}

}
