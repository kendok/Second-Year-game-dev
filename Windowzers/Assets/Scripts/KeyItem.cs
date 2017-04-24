using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag ("key1")) {			//if player gets key  

			Debug.Log("You got a magical key");
			GameVariables.keyCount ++; 		// adds one to the keycount
		
			Destroy (hit.gameObject);
		}

	}
}
