using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<BossHealthManager> ())  // checks to see if there is any boss in the level if there is continues to update
		{
			return;
		}

		Destroy (gameObject);  // if there is no boss will destroy the Wall

	}

}
