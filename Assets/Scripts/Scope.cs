﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

	public Animator animator;

	public GameObject scopeOverlay;
	public GameObject weaponsCamera;
	public Camera mainCamera;

	public float scopedFOV = 15f;
	private float normalFOV;

	private bool isScoped = false;

	void Update (){

		if (Input.GetButtonDown ("Fire2")) {
			isScoped = !isScoped;
			animator.SetBool ("Scoped", isScoped);

			if (isScoped)
				StartCoroutine(OnScoped());
			else
				OnUnscoped ();
		}
	}

	void  OnUnscoped (){
		scopeOverlay.SetActive (false);
		weaponsCamera.SetActive (true);

		mainCamera.fieldOfView = normalFOV;
	}

	IEnumerator OnScoped () {

		yield return new WaitForSeconds (.15f);

		scopeOverlay.SetActive (true);
		weaponsCamera.SetActive (false);

		normalFOV = mainCamera.fieldOfView;
		mainCamera.fieldOfView = scopedFOV;
	}
}
