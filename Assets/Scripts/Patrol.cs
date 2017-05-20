using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPC {
	public Transform[] patrolPoints;
	public float moveSpeed;
	private int currentPoint;


	bool isWaiting = false;
	public float pauseDuration = 2f;
	float currentPauseTimer;

	bool isAwareOfPlayer = false;

	// Use this for initialization
	// The enemy will have patrolpoint to move from one point to another one when the game is switched on
	protected override void Awake () {
		// this tells the method to execute the one before it
		base.Awake ();
		transform.position = patrolPoints [0].position;
		currentPoint = 0;
	}

	// Update is called once per frame
	void Update () {

		if (!isAwareOfPlayer) {
			Walking ();
		}

	}


	void Walking () {

		if (transform.position == patrolPoints [currentPoint].position) {

			if (!isWaiting) {
				
				m_animator.SetTrigger ("Forward");
				isWaiting = true;

			} else {
				
				if (currentPauseTimer < pauseDuration) {
					currentPauseTimer += Time.deltaTime;
				} else {

					// reset the waiting time
					isWaiting = false;
					currentPauseTimer = 0f;

					// trigger the walk animation
					m_animator.SetTrigger ("Forward");

					// set the point to move towards
					currentPoint = (currentPoint + 1) % patrolPoints.Length;
					transform.LookAt (patrolPoints [currentPoint].position);
				}

			}

		} else {
			
			transform.position = Vector3.MoveTowards (transform.position, patrolPoints [currentPoint].position, moveSpeed * Time.deltaTime);

		}


	}

	public override void React () {
		// if you want to start off from the default method, keep this line
		base.React ();


	}

}
