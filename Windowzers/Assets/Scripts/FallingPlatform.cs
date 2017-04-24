using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float fallDelay; 		// to set the platform when to fall

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.CompareTag ("Player")) { // if player hits the platform
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds (fallDelay);
		rb2d.isKinematic = false;
		GetComponent<Collider2D> ().isTrigger = true; // to make it fall through the world
		yield return 0;
	}

}
