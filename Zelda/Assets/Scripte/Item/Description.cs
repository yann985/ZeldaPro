using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{
    
    [SerializeField] TMP_Text Non;
    [SerializeField] TMP_Text Texte;
    [SerializeField] GameObject gameObject;

    public void SetText(string  non, string description)
    {
        Non.text=non;
        Texte.text=description;
        
        
    }
    void Update()
    {
        if(!gameObject.activeSelf)
        {
             DescriptionMessage.instanc.Cacher();
        }
    }



}
