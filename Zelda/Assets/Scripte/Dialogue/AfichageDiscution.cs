using UnityEngine;
using TMPro;
using System;
using System.Collections;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class AfichageDiscution : MonoBehaviour
{
    [SerializeField]string Nom;
    [SerializeField,TextArea(4,6)]string [] Dialogue;
    
    [SerializeField] GameObject Panel;
    [SerializeField] TMP_Text Text;
    [SerializeField] float DailerAfichage;
    
   private bool DialoguePossible;
   private bool DialogueStarte;
   private int IndexDialogue;
   
    void Update()
    {
        if (DialoguePossible && Input.GetKeyDown(KeyCode.E))
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Nom))
        {
             DialoguePossible=true;
        }
       Debug.Log("124");


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Nom))
        {
            DialoguePossible=false;
        }
        Debug.Log("125");

    }


}
