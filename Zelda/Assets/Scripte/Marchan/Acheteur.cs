using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class Acheteur : MonoBehaviour
{
    [SerializeField] private Inventaire inventaire;
    [SerializeField] GameObject PanelleComerce;
    [SerializeField] GameObject PanelleAchat;
    [SerializeField] GameObject PanelleVante;
     [SerializeField] ItemData itemData;
     public string nameitem;
     public TMP_Text textItem;
     public Image image;
     int NobrePoche = 81;
     bool marchan;
    
    [SerializeField]Button button;
    
    public void BuyItem(ItemData itemData)
    {
        if (!Inventaire.Instance.InventairePlein())
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
        if (context.performed)
        {
            if ( marchan)
        {
             Time.timeScale=1;
            Inventaire.Instance.marchan=true;
            PanelleComerce.SetActive(true);
            button.Select();

        }
        }
    }
     public void Quitter(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (marchan)
        {
            PanelleAchat.SetActive(false);
            PanelleVante.SetActive(false);
            if ( !PanelleAchat.activeSelf && !PanelleVante.activeSelf)
            {
                Time.timeScale=0;
                PanelleComerce.SetActive(false);
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
     
            PanelleVante.SetActive(true);
    }
    public void ActivePanelAchat()
    {
         PanelleAchat.SetActive(true);
           
    }

}
