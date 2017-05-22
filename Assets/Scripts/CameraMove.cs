using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	Vector3 defaultRotation;
	float rotationLimit = 90f;

	void Start () {
		defaultRotation = transform.rotation.eulerAngles;
	}

	void Update () {

		Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition) - new Vector3(0.5f, 0.5f);
		pos = defaultRotation + (rotationLimit * new Vector3(-pos.y, pos.x));

		transform.rotation = Quaternion.Euler (pos);

	}
}
