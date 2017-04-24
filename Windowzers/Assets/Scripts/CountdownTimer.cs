using UnityEngine;
using System.Collections;
// this script was one matt used in gravity guy
public class CountdownTimer : MonoBehaviour 
{
	private float countdownTimerStartTime;
	private int countdownTimerDuration;

	//-----------------------------
	public int GetTotalSeconds()
	{
		return countdownTimerDuration;
	}

	//-----------------------------
	public void ResetTimer(int seconds)
	{
		countdownTimerStartTime = Time.time;
		countdownTimerDuration = seconds;
	}

	//-----------------------------
	public int GetSecondsRemaining(int timeToAdd)
	{
		int elapsedSeconds = GetElapsedSeconds();
		int secondsLeft = (countdownTimerDuration - elapsedSeconds) + timeToAdd;
		return secondsLeft;
	}

	//-----------------------------
	public int GetElapsedSeconds()
	{
		int elapsedSeconds = (int)(Time.time - countdownTimerStartTime);
		return elapsedSeconds;
	}

	//-----------------------------
	public float GetProportionTimeRemaining()
	{
		float proportionLeft = (float)GetSecondsRemaining(0) / (float)GetTotalSeconds();
		return proportionLeft;
	}


}
