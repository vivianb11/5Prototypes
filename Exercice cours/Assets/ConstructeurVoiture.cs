using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructeurVoiture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Voiture ma1erVoiture = new("Citroen");
        Voiture ma2emeVoiture = new("Peugeot", 210, Color.black);
    }
}

class Voiture
{
    private string nomVoiture;
    private int vitesseVoiture;
    private Color couleurVoiture;

    public Voiture(string sonNom,int saVitesse, Color saCouleur)
    {
        nomVoiture = sonNom;
        vitesseVoiture = saVitesse;
        couleurVoiture = saCouleur;
        WriteInfo();
    }

    public Voiture(string nomMaVoiture)
    {
        nomVoiture = nomMaVoiture;
        vitesseVoiture = 180;
        couleurVoiture = Random.ColorHSV();
        WriteInfo();
    }

    private void WriteInfo()
    {
        Debug.Log(nomVoiture + " roule a " + vitesseVoiture + " et est " + couleurVoiture);
    }
}
