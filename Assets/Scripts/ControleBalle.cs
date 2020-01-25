using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBalle : MonoBehaviour
{

	[SerializeField]
	float vitesse;

	float rayon;

	Vector2 direction;

	bool estEnMouvement = false;

    // Start is called before the first frame update
    void Start()
    {
        rayon = transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {

    	// initie le mouvement de la balle
    	if (Input.GetKey("space")){
    		// positionne la balle au centre du terrain
    		transform.position = new Vector2(0, 0);

    		// choisi au hasrd un angle de départ exprimé en radian
    		float angle = Random.Range(0.0f, 2.0f * Mathf.PI);

    		// calcule la direction de la balle en fonction de l'angle de départ
    		direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

		    estEnMouvement = true;
	    }

	    // poursuit le mouvement de la balle
    	if (estEnMouvement){
		    transform.Translate(direction * vitesse * Time.deltaTime);
	    }
        
    }

    // programmer la réaction de la balle lorsqu'elle entre en colision avec une raquette
    void OnTriggerEnter2D(Collider2D objet){

		// inverser la direction de la balle
    	if(objet.tag == "RaquetteDroite" && direction.x > 0) {
    			direction.x = -direction.x;
    	}
    	if(objet.tag == "RaquetteGauche" && direction.x < 0) {
    			direction.x = -direction.x;
    	}
    	
    }
}
