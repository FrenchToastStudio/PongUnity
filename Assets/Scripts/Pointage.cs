using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointage : MonoBehaviour
{

	private int pointDroite = 0;
    private int pointGauche = 0;
    
    public void ajouterPointDroite() {
        pointDroite += 1;
    }

    public int getPointDroite() {
        return pointDroite;
    }

    public void ajouterPointGauche() {
        pointGauche += 1;
    }

    public int getPointGauche() {
        return pointGauche;
    }

}
