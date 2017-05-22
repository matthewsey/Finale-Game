using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

	// this is the game time limit
	public float timeLimit = 30f;

	// when did this level start?
	protected float endTime;

	// the Time Limit Text
	public Text timeLimitText;


	void Start () {
	
		// Time.time = the time since the game was launched
		// what time should the level end?
		// (assuming the level can't be paused)
		endTime = Time.time + timeLimit;

	}


	void Update () {

		// how much time is left?
		int timeLeft = Mathf.CeilToInt(endTime - Time.time);

		// write the time left to the screen
		timeLimitText.text = "Time Left: " + timeLeft;

		// change the scene only when the time is up
		if (timeLeft <= 0) {
			SceneManager.LoadScene ("GameOver Scene");
		}

	}

}
