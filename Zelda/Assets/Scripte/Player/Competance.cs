using UnityEngine;
using UnityEngine.InputSystem;
public class Competance : MonoBehaviour
{
    [SerializeField] AbtitudePlayer  abtitudePlayer;
    [SerializeField] Attaque  attaque;
    [SerializeField] GameObject panel;
    bool autel;
    
     void AfichageMenuAmelioration(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            panel.SetActive(true);
            Time.timeScale=0;
        }
    }
     void FermeturMenuAmelioration(InputAction.CallbackContext context)
    {
        if (context.performed)
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
        abtitudePlayer.vie+=10;
        abtitudePlayer.vieMax+=10;
   }
   public void AjoutEndurance()
   {
        abtitudePlayer.Enduro+=20;
        abtitudePlayer.EnduroMax+=20;
   }
   public void AjoutForce()
   {
    attaque.forc+=10;
   }
   public void AjoutManiman()
   {
        
       attaque.hemorragie+=2;  
       attaque.empoisonnement+=2;
       attaque.fracture+=2;
   }
}
