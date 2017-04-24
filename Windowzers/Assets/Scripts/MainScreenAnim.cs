using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenAnim : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim.SetBool ("isPlaying", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
