using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBalle : MonoBehaviour
{

	[SerializeField]
	float vitesse;

	private float rayon;

	private Vector2 direction;

	private bool estEnMouvement = false;

    // Start is called before the first frame update
    void Start()
    {
        rayon = transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {

    	float angle = 0.0f;

    	// initie le mouvement de la balle
    	if (Input.GetKey("space") && !estEnMouvement){
    		// positionne la balle au centre du terrain
    		transform.position = new Vector2(0, 0);

    		// choisi au hasrd un angle de départ exprimé en radian
    		// le premier random choisi en direction de quel joueur, le 2e choisi un angle entre 1/3PI et -1/3PI
    		if(Mathf.Round(Random.Range(0.0f, 1.0f)) == 0) {
    			angle = Random.Range(- Mathf.PI / 6, Mathf.PI / 6);
    		} else {
    			angle = Random.Range(5 * Mathf.PI / 6, 7 * Mathf.PI / 6);
    		}

    		// calcule la direction de la balle en fonction de l'angle de départ
    		direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

		    estEnMouvement = true;
	    }

	    // poursuit le mouvement de la balle
    	if (estEnMouvement){
		    transform.Translate(direction * vitesse * Time.deltaTime);
	    }
        
    }

    // programmer la réaction de la balle lorsqu'elle entre en collision avec une raquette
    void OnTriggerEnter2D(Collider2D objet){

		// inverser la direction de la balle lorsqu'elle entre en collision avec une raquette
    	if(objet.tag == "RaquetteDroite" && direction.x > 0) {
    			direction.x = -direction.x;
    	}
    	if(objet.tag == "RaquetteGauche" && direction.x < 0) {
    			direction.x = -direction.x;
    	}

    	// inverser la direction de la balle lorsqu'elle entre en collision avec le haut ou le bas du terrain
    	if(objet.tag == "TerrainHaut" || objet.tag == "TerrainBas") {
    		direction.y = -direction.y;
    	}

    	// arrêter la balle et la remettre au centre, lorsqu'elle entre en collision avec le fond du terrain
    	if(objet.tag == "TerrainFond") {
    		// positionne la balle au centre du terrain
    		transform.position = new Vector2(0, 0);
    		
    		estEnMouvement = false;
    	}
    }
}
