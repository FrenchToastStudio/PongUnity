﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControleRaquette : MonoBehaviour
{

	private Rigidbody raquette;
	private float position;

    // Start is called before the first frame update
    void Start()
    {
    	// récupère la position verticale de la raquette 
 	    position = transform.position.x;
	    raquette = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKey("up")){
		    float y = transform.position.y + 0.1f;
		    transform.position = new Vector2(transform.position.x, y);
	    }
	    if (Input.GetKey("down")){
		    float y = transform.position.y - 0.1f;
		    transform.position = new Vector2(transform.position.x, y);
	    }
    }
}