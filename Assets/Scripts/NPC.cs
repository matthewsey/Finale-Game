using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	protected Animator m_animator;

	protected virtual void Awake () {

		m_animator = GetComponent <Animator> ();

	}

	public virtual void React () {
		// if you want to make any default actions, do this here.
	}

}
