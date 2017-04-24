using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth; 		// this script looks after the lady zombies as it takes 2 hits to kill them



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Destroy (gameObject);

		}
	}
	public void giveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive; 		//damage the boss 

	}
}
