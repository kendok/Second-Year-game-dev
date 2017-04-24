using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

	public int bossHealth;

	public GameObject deathEffect;

	public GameObject bossPrefab; // to set the prefab for the boss so when he breaks up

	public float minSize; 		// to set how small the zombie explosions 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (bossHealth <= 0) 		
		{
			Instantiate (deathEffect, transform.position, transform.rotation);
	

			if (transform.localScale.y > minSize) 
			{
				GameObject clone1 = Instantiate (bossPrefab, new Vector3 (transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation)as GameObject;   // Creating new game objects
				GameObject clone2 = Instantiate (bossPrefab, new Vector3 (transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation)as GameObject;


				clone1.transform.localScale = new Vector3 (transform.localScale.y * 0.5f,transform.localScale.y* 0.5f, transform.transform.localScale.z); // spawns zombie half the size of previous
				clone1.GetComponent<BossHealthManager> ().bossHealth = 8; //makes sure he has health

				clone2.transform.localScale = new Vector3 (transform.localScale.y * 0.5f,transform.localScale.y* 0.5f, transform.transform.localScale.z);// spawns zombie half the size of previous
				clone2.GetComponent<BossHealthManager> ().bossHealth = 8;
			}

			Destroy (gameObject);
		
		}

	}

	public void giveDamage(int damageToGive)
	{
		bossHealth -= damageToGive; 		//damage the boss 

	}
}
