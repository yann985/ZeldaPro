using UnityEngine;

public class Mouve : MonoBehaviour
{
    public Animation animatio;
    public float walkSpeed;
    public float runSpeed;

    // Imputs
    public string droit;
    public string gauche;
    public string bas;
    public string haut;
   
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(droit) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(walkSpeed*Time.deltaTime,0,0);
            //animatio.Play("marche");
        }

        if(Input.GetKey(droit) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(walkSpeed*Time.deltaTime,0,0);
            //animatio.Play("marche");
        }

         if(Input.GetKey(gauche) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-walkSpeed*Time.deltaTime,0,0);
            //animatio.Play("marche");
        }

        if(Input.GetKey(gauche) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-walkSpeed*Time.deltaTime,0,0);
            //animatio.Play("marche");
        }
         if(Input.GetKey(haut) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,walkSpeed*Time.deltaTime,0);
            //animatio.Play("marche");
        }

        if(Input.GetKey(haut) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,walkSpeed*Time.deltaTime,0);
            //animatio.Play("marche");
        }
         if(Input.GetKey(bas) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,-walkSpeed*Time.deltaTime,0);
            //animatio.Play("marche"); 
        }

         if(Input.GetKey(bas) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0,-walkSpeed*Time.deltaTime,0);
            //animatio.Play("marche"); 
        }

        // ne bouge pas 
        if(!Input.anyKeyDown)
        {
            
            //animatio.Play("marche"); 
        }
    }
}
