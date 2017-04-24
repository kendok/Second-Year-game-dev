using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {
	// These methods is to clear out the memory by destroying the penguin bombs over time
	public float lifeTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;		//make the lifetime countdown

		if (lifeTime < 0) 				
		{
			Destroy (gameObject);		//this destroys the object from memory
		}
	}
}
