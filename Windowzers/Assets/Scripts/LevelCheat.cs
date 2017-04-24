using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCheat : MonoBehaviour {

	public string Bossfight; // making a variable that can drag which scene we want to load
	public string lvl2;



	public void Boss()
	{
		SceneManager.LoadScene (Bossfight); 

	}
	public void Level2()
	{
		SceneManager.LoadScene (lvl2); 

	}
}
