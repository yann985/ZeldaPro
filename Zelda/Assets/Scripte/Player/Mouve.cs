using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouve : MonoBehaviour
{
   
    [SerializeField]  float walkSpeed;
    [SerializeField]  float runSpeed;
    bool Spreent;
    bool Dega;
    float DuraiEsquive=10;
    [SerializeField]  Vector3 directo;
    public  Vector3 directoFrape;
    Vector3 VitesseDeplacement;
    [SerializeField] Animator animator;
     [SerializeField] AbtitudePlayer abtitudePlayer;
    
    
    // Imputs
   
    void Update()
    {
       
        if(!Spreent)
        {
            VitesseDeplacement = directo * Time.deltaTime * walkSpeed;
        }
        else
        {
            if(abtitudePlayer.Enduro>=1)
            {
                abtitudePlayer.Enduro-=0.5f;
                VitesseDeplacement = directo * Time.deltaTime * walkSpeed*runSpeed;
            }
            else
            {
                Spreent=false;
            }
            
        }
        if((DuraiEsquive+=Time.deltaTime)<0.05 && Time.timeScale==1)
        {
             if(abtitudePlayer.Enduro>0)
            {
            
              transform.position += VitesseDeplacement*2; 
            }
        }
        else
        {
            Dega=true;
        }
       
        

        transform.position += VitesseDeplacement;
        animator.SetFloat("DirectionX",directo.x);
        animator.SetFloat("DireectionY",directo.y);
        
        

        Debug.Log(VitesseDeplacement);
    }
    

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 input = context.ReadValue<Vector3>();
           directo =input;
           directoFrape=input.normalized;
           animator.SetBool("Marche",true);
        }
        else if (context.canceled)
        {
            directo = Vector2.zero;
            Spreent=false;
            animator.SetBool("Marche",false);
            VitesseDeplacement=Vector2.zero;
        }
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           
           Spreent=!Spreent;
        }
        
    }
    public void Esquiver(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(abtitudePlayer.Enduro>20)
            {
                abtitudePlayer.Enduro-=50f;
                DuraiEsquive=0;
                Dega=false;
            }
            
          
           
        }
       
    }

}
