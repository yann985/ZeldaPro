using UnityEngine;

public class RetourJeu : MonoBehaviour
{
    GameObject gameObject;

   
    void Retour()
    {
        Time.timeScale=1;
        gameObject.SetActive(false);
    }
    
}
