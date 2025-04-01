using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using System.Diagnostics;


public class Acheteur : MonoBehaviour
{
    [SerializeField] private Inventaire inventaire;
    [SerializeField] GameObject PanelleComerce;
    [SerializeField] GameObject PanelleAchat;
    [SerializeField] GameObject PanelleVante;
     [SerializeField] ItemData itemData;
     [SerializeField] float DailerAfichage;
    
     public string nameitem;
     public TMP_Text textItem;
     public Image image;
     int NobrePoche = 81;
     bool marchan;
    
    [SerializeField]Button button;

    [SerializeField]Button buttonVente;
    [SerializeField]Button buttonAchat;
    bool tempReaction;
   
    
    public void BuyItem(ItemData itemData)
    {
        if (!Inventaire.Instance.InventairePlein() && Inventaire.Instance.argent >itemData.valus)
        {
            Inventaire.Instance.AjouterItem(itemData);
            if(Inventaire.Instance.argent > itemData.valus)
            {
                Inventaire.Instance.argent -= itemData.valus;
            }
            
        }
    }
    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if ( marchan && !PanelleAchat.activeSelf && !PanelleVante.activeSelf && !PanelleComerce.activeSelf)
        {
            Time.timeScale=0;
            Inventaire.Instance.marchan=true;
            PanelleComerce.SetActive(true);
            button.Select();
            
            StartCoroutine(AttendAparitionEcran());

        }
        

        }

    }
     public void Quitter(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
             
            if (marchan)
        {
            
            if ( PanelleAchat.activeSelf || PanelleVante.activeSelf || PanelleComerce.activeSelf)
            {
                PanelleAchat.SetActive(false);
                PanelleVante.SetActive(false);
                
                PanelleComerce.SetActive(!PanelleComerce.activeSelf);
                if (!PanelleComerce.activeSelf &&  !PanelleVante.activeSelf && !PanelleAchat.activeSelf )
                {
                    Time.timeScale=1;
                    StopCoroutine(AttendAparitionEcran());
                     tempReaction=false;
                }
                Inventaire.Instance.marchan=false;
               
                
            }
            

            
            
            button.Select();

        }
        }
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
    
        if (collision.gameObject.layer==6)
        {
             marchan=true;
        }


    
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
    
        if (collision.gameObject.layer==6)
        {
            marchan=false;
        }


    
    }
    public void ActivePanelVent()
    {
     
            if(tempReaction)
            {
            PanelleVante.SetActive(true);
            buttonVente.Select();
            PanelleComerce.SetActive(false);
            Inventaire.Instance.marchan=true;
            }

        
     

            
    }
    public void ActivePanelAchat()
    {
        if(tempReaction)
        {
             PanelleAchat.SetActive(true);
         buttonAchat.Select();
         PanelleComerce.SetActive(false);
        }
        
           
        
         
           
    }
    private IEnumerator AttendAparitionEcran()
    {
         yield return new WaitForSecondsRealtime(DailerAfichage);
        tempReaction=true;
        UnityEngine.Debug.Log(tempReaction);
        
        
          
       
        
        
        
    }

}
