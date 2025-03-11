using UnityEngine;
using TMPro;
using System;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class AfichageDiscutionQuete : MonoBehaviour
{
    [SerializeField]string Nom;
    [SerializeField,TextArea(4,6)]string [] francai;
   [SerializeField,TextArea(4,6)]string [] espagnol;
    
    [SerializeField] GameObject Panel;
    [SerializeField] TMP_Text Text;
    [SerializeField] float DailerAfichage;
    [SerializeField] QueteInteraction queteInteraction;
    [SerializeField] int activationQuete;
    
   
   private bool DialogueStarte;
   private int IndexDialogue;
   bool traduction=false;
   string [] Dialogue ;

    
    void Start()
        {
            if(!traduction)
            {
               Dialogue = francai;
            }
            else
            {
                Dialogue = espagnol;
            }
        }
    public void GestionDialog()
    {
        
            if(!DialogueStarte)
            {
                StarteDialog();
            }
            else if (Text.text==Dialogue[IndexDialogue])
            {
                LigneSuivente();
            }
            else
            {
                StopAllCoroutines();
                Text.text=Dialogue[IndexDialogue];

            }
        
    }

    private void StarteDialog()
    {
        DialogueStarte=true;
        Panel.SetActive(true);
        IndexDialogue=0;
        StartCoroutine(ShowLIgne());
        Time.timeScale=0f;
    }
    void LigneSuivente()
    {
        IndexDialogue++;
        if (IndexDialogue<Dialogue.Length)
        {
            StartCoroutine(ShowLIgne());
        }
        else 
        {
            DialogueStarte=false;
            Panel.SetActive(false);
            Time.timeScale=1f;
            if(queteInteraction.Progrétion==activationQuete)
            {
                queteInteraction.Progrétion++;
            }

        }
    }
    private IEnumerator ShowLIgne()
    {
        Text.text=string.Empty;
        foreach(char ch in Dialogue[IndexDialogue])
        {
            Text.text+=ch;
            yield return new WaitForSecondsRealtime(DailerAfichage);
        }
        
    }


}
