using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRandomSpawn : MonoBehaviour
{
	public Transform[] teleport;		// places want key to spawn 
	public GameObject prefab;			// the actual key

	void Start ()
	{
		print (teleport.Length);
		keySpawn ();
	}

	void keySpawn ()
	{
		// Get a random transform from selection
		// teleport [ (random index between 0 and length) ];
		Transform tele = teleport [Random.Range (0, teleport.Length)];

		// Get a random GameObject prefab from selection
		// teleport [ (random index between 0 and length) ];
	//	GameObject pref = prefab [Random.Range (0, prefab.Length)];

		// Create new GameObject
		// Instantiate (the game object, a transform with position, rotation, scale)
		GameObject c = Instantiate (prefab, tele) as GameObject;
		c.transform.position = tele.position;

	}
}

 // this script was ALOT HARDER then it should have been 

/*
 * 
 		tryed this way but didnt work  found 
	public Transform[] spawnLocations;
	public GameObject[] keyPrefab;
	public GameObject[] keyClone;

	void start(){
		spawnKeys ();
	}

	void spawnKeys()
	{
		keyClone [0] = Instantiate (keyPrefab[0],spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
	}





// then tried this way

	public Vector3[] positions;

		void start(){
			int randomNumber = Random.Range (0,positions.Length);
			transform.position = positions[randomNumber];

		}


// third time
	public Transform[] teleport;		// places want key to spawn 
	public GameObject[] prefeb;			// the actual key

	void Start(){ //this will spawn only one prefeb of the key in 3 locations, 
		
		keySpawn ();
	}
	public GameObject keySpawn(){
		
		int tele_num = Random.Range(0,teleport.Length);
		int prefeb_num = Random.Range(0,prefeb.Length);

		GameObject c = Instantiate(prefeb[prefeb_num], teleport[tele_num].position, teleport[tele_num].rotation ) as GameObject; // spawning key in random postion

		return c;
	}


}












	*/