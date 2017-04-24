using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// done with help of script https://youtube.com/watch?v=30OuWY1UfcQ
public class ParaRelaxing : MonoBehaviour {

	public Transform[] backgrounds; 
	private float [] parralaxScales; // ammount of movement it moves when camera is moving
	public float smoothing; // how smooths it moves 


	private Vector3 previousCameraPosition; // find where camera last postion on last frame

	// Use this for initialization
	void Start () {
		previousCameraPosition = transform.position; 

		parralaxScales = new float[backgrounds.Length]; // to make sure it is the same size as backgrounds array
		for (int i = 0; i < parralaxScales.Length; i++)  // goes through array and decided how far should be in distance 
		{
			parralaxScales[i] = backgrounds[i].position.z * -1;
		}

	}
	
	// our parralaxing happens after camaera has moved
	void LateUpdate () {
		for(int i = 0; i < backgrounds.Length; i++)
		{	//how much movement need to happen and how quick 
			Vector3 parallax = (previousCameraPosition - transform.position) * (parralaxScales [i] / smoothing);
			//adding to current position
			backgrounds [i].position = new Vector3 (backgrounds [i].position.x + parallax.x, backgrounds [i].position.y + parallax.y, backgrounds [i].position.z);
		}

		previousCameraPosition = transform.position;
		
	}
}
