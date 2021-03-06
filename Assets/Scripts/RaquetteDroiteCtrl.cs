﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaquetteDroiteCtrl : MonoBehaviour
{

    [SerializeField]
    float uniteDeplacement = 0.1f;

    private bool estHorsLimiteHaut = false;
    private bool estHorsLimiteBas = false;

    // Update is called once per frame
    void Update()
    {
    	if (!estHorsLimiteHaut && Input.GetKey("up")){
            float y = transform.position.y + uniteDeplacement;
            transform.position = new Vector2(transform.position.x, y);
            estHorsLimiteBas = false;
        }
        if (!estHorsLimiteBas && Input.GetKey("down")){
            float y = transform.position.y - uniteDeplacement;
            transform.position = new Vector2(transform.position.x, y);
            estHorsLimiteHaut = false;
        }
    }

    // empêcher la raquette de sortir du terrain
    void OnTriggerEnter2D(Collider2D objet){

    	// détecter la collision de la raquette avec le haut ou le bas du terrain
        if(objet.tag == "TerrainHaut") {
            estHorsLimiteHaut = true;
        }
        if(objet.tag == "TerrainBas") {
            estHorsLimiteBas = true;
        }
    }
}
