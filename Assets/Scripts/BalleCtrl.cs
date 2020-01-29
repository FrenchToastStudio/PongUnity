using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleCtrl : MonoBehaviour
{

	[SerializeField]
	float vitesse;

	private float rayon;

	private Vector2 direction;

	private bool estEnMouvement = false;

    public Pointage pointage;

    // Start is called before the first frame update
    void Start()
    {
        // le rayon est la moitié du diamètre de la balle en coordonnées locales
        rayon = transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {

    	float angle = 0.0f;

    	// initie le mouvement de la balle
    	if (!estEnMouvement && Input.GetKey("space")){
    		// positionne la balle au centre du terrain
    		transform.position = new Vector2(0, 0);

    		// choisi au hasard un angle de départ exprimé en radian
    		// le premier random choisi en direction de quel joueur (0 = droite ou 1 = gauche), 
            // le 2e choisi un angle entre 1/6PI et -1/6PI (vers la droite)
            // ou 5/6PI et 7/6PI (vers la gauche) ref. cercle trigonométrique
    		if(Random.Range(0f, 1f) %2 == 0) {
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
        if(objet.tag == "Raquette") {
            direction.x = -direction.x;
        }

    	// inverser la direction de la balle lorsqu'elle entre en collision avec le haut ou le bas du terrain
        if(objet.tag == "TerrainHaut" || objet.tag == "TerrainBas") {
            direction.y = -direction.y;
        }

    	// arrêter la balle et la remettre au centre, lorsqu'elle entre en collision avec le fond du terrain
        if(objet.tag == "TerrainFondDroite" || objet.tag == "TerrainFondGauche") {
    		
            // positionne la balle au centre du terrain
            transform.position = new Vector2(0, 0);

            estEnMouvement = false;

            if(objet.tag == "TerrainFondGauche") {
                pointage.ajouterPointDroite();
            } else {
                pointage.ajouterPointGauche();
            }
        }
    }
}
