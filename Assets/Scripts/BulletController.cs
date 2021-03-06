﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour {

    //the bullet speed
    protected float speed = 55f;

    //the bullet's life span
    protected float lifeSpan = 6f;

    //a reference to the bullet's physics component
    protected Rigidbody _rigibody;

    bool isAlive = true;

    //when the script wakes up
    void Awake (){

        _rigibody = GetComponent<Rigidbody>();

    }

    //when the script launches, push the bullet
    void Start (){

        //find where I'm looing for the world's prespective
        Vector3 fwd = transform.TransformDirection (Vector3.forward);

        //push the bullet forward depending on where I'm looking 
        _rigibody.AddForce(fwd * speed, ForceMode.Impulse);

    }

    //move the bullet on every frame
    void Update ()
    {
        


        //Time.deltaTime = time passed between frames
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0f) {
            Destroy(gameObject);
        }


    }


    //when the bullet collides with anything, it is removed from play
    void OnCollisionEnter (Collision c){
		Destroy (gameObject);

        //if the enemy is hit kil them
		if (c.gameObject.tag == "soldier"){
            c.gameObject.GetComponent<Patrol>().Die();
        }

       




    }
    

    }

	

