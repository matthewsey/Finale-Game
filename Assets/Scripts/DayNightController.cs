using UnityEngine;
using System.Collections;
using System;

public class DayNightController : MonoBehaviour {

	protected const int DAY_IN_SECONDS = 24 * 60 * 60;

	protected Light sun;
	public float secondsInFullDay = 120f;
	[Range(0,1)]
	public float currentTimeOfDay = 0;
	[HideInInspector]
	public float timeMultiplier = 1f;

	float sunInitialIntensity;

	float CurrentTimeInDay () {

		int hour_seconds = DateTime.Now.Hour * 60 * 60;
		int minute_seconds = DateTime.Now.Minute * 60;
		int seconds = DateTime.Now.Second + minute_seconds + hour_seconds;

		return ((float) seconds / (float) DAY_IN_SECONDS);

	}

	void Start() {
		sun = GetComponent <Light> ();

		sunInitialIntensity = sun.intensity;
	}

	void Update() {
		sun.transform.rotation = Quaternion.Euler ((CurrentTimeInDay () * 360f) - 90, 170, 0);
	}


}
