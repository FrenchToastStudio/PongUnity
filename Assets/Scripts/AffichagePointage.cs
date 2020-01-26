using UnityEngine;
using UnityEngine.UI;

public class AffichagePointage : MonoBehaviour
{

	[SerializeField]
	Pointage points;

	private Text affichagePoints;

    // Start is called before the first frame update
    void Start()
    {
        affichagePoints = GetComponent<Text>();
        Debug.Log("gameObject.tag : " + gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {

    	if(gameObject.tag == "PointDroite") {
        	affichagePoints.text = points.getPointDroite().ToString();
        } else {
        	affichagePoints.text = points.getPointGauche().ToString();
        }
    }
}
