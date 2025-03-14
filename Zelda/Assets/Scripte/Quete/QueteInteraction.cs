using UnityEngine;
using UnityEngine.InputSystem;
public class QueteInteraction : MonoBehaviour
{
    [SerializeField]string Nom;
    [SerializeField] AfichageDiscutionQuete[] Quetes;
    private bool DialoguePossible;
    public int Progrétion=0;
    
     public void Interaction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (DialoguePossible )
        {
            Quetes[Progrétion].GestionDialog();
        }
        }
    }
    
        
        
    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==6)
        {
             DialoguePossible=true;
        }
       Debug.Log("124");


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer==6)
        {
            DialoguePossible=false;
        }
        Debug.Log("125");

    }


}
