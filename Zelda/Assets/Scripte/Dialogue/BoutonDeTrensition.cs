using UnityEngine;

using TMPro;

public class BoutonDeTrensition : MonoBehaviour
{
     [SerializeField] TMP_Text Text;
    void Start()
    {
        Text.text="Français";
    }

    public  void traduction()
   {
    if(Manadjeur.instance.traduction<2)
    {
     Manadjeur.instance.traduction++;
    }
    else 
    {
     Manadjeur.instance.traduction=0;
    }

    if (Manadjeur.instance.traduction==0)
    {
         Text.text="Français";
      
    }
    else if(Manadjeur.instance.traduction==1)
    {
     Text.text="Castellano";
    }
    else if(Manadjeur.instance.traduction==2)
    {
          Text.text="català";
    }
    
   }
   

}
