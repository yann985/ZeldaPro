using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Competance : MonoBehaviour
{
    [SerializeField] AbtitudePlayer  abtitudePlayer;
    [SerializeField] Attaque  attaque;
    [SerializeField] GameObject panel;
    [SerializeField] XP xP;
    [SerializeField] TMP_Text tMP_Text;
    bool autel;
    void Update()
    {
         

    if (Manadjeur.instance.traduction==0)
    {
        tMP_Text.text="Vos points de compétence"+xP.poinDeConpetance.ToString();
      
    }
    else if(Manadjeur.instance.traduction==1)
    {
        tMP_Text.text="Tus puntos de habilidad"+xP.poinDeConpetance.ToString();
    }
    else if(Manadjeur.instance.traduction==2)
    {
        tMP_Text.text="Els teus punts d'habilitat"+xP.poinDeConpetance.ToString();
    }
    
   
        
    }
   

    public void AfichageMenuAmelioration(InputAction.CallbackContext context)
    {
        if (context.performed && autel)
        {
            panel.SetActive(true);
            Time.timeScale=0;
        }
    }
    public void FermeturMenuAmelioration(InputAction.CallbackContext context)
    {
        if (context.performed && autel)
        {
             panel.SetActive(false);
             Time.timeScale=1;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
    
        if (collision.gameObject.layer==6)
        {
            autel=true;
        }


    
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
    
        if (collision.gameObject.layer==6)
        {
             autel=false;
        }


    
    }

   public void AjoutVie()
   {
        if(xP.poinDeConpetance!=0)
        {
            abtitudePlayer.vie+=10;
        abtitudePlayer.vieMax+=10;
        xP.poinDeConpetance--;
        }
        
   }
   public void AjoutEndurance()
   {
        if(xP.poinDeConpetance!=0)
        {
            abtitudePlayer.Enduro+=20;
        abtitudePlayer.EnduroMax+=20;
        xP.poinDeConpetance--;
        }
        
   }
   public void AjoutForce()
   {
    if(xP.poinDeConpetance!=0)
    {
        attaque.forc+=10;
        xP.poinDeConpetance--;
    }
    
   }
   public void AjoutManiman()
   {
        if(xP.poinDeConpetance!=0)
        {
            attaque.hemorragie+=2;  
       attaque.empoisonnement+=2;
       attaque.fracture+=2;
       xP.poinDeConpetance--;
        }
       
   }
}
