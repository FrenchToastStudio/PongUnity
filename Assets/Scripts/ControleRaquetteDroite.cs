using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControleRaquetteDroite : MonoBehaviour
{

	private float position;
	private bool estHorsLimiteHaut = false;
	private bool estHorsLimiteBas = false;

    // Start is called before the first frame update
    void Start()
    {
    	// récupère la position verticale de la raquette 
 	    position = transform.position.x;      
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKey("up") && !estHorsLimiteHaut){
		    float y = transform.position.y + 0.1f;
		    transform.position = new Vector2(transform.position.x, y);
		    estHorsLimiteBas = false;
	    }
	    if (Input.GetKey("down") && !estHorsLimiteBas){
		    float y = transform.position.y - 0.1f;
		    transform.position = new Vector2(transform.position.x, y);
		    estHorsLimiteHaut = false;
	    }
    }

    // empêcher la raquette de sortir du terrain
    void OnTriggerEnter2D(Collider2D objet){

    	// inverser la direction de la balle lorsqu'elle entre en collision avec le haut ou le bas du terrain
    	if(objet.tag == "TerrainHaut") {
    		estHorsLimiteHaut = true;
    	}
    	if(objet.tag == "TerrainBas") {
    		estHorsLimiteBas = true;
    	}
    }
}
