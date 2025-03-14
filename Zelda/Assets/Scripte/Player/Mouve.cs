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
    
    // Imputs
   
    void Update()
    {
       
        if(!Spreent)
        {
            VitesseDeplacement= directo * Time.deltaTime * walkSpeed;
        }
        else
        {
            VitesseDeplacement = directo * Time.deltaTime * walkSpeed*runSpeed;
        }
        if((DuraiEsquive+=Time.deltaTime)<0.05)
        {
            VitesseDeplacement += directo; 
        }
        else
        {
            Dega=true;
        }

        transform.position +=VitesseDeplacement;
        
        


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
            directo = Vector3.zero;
            Spreent=false;
            animator.SetBool("Marche",false);
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
          DuraiEsquive=0;
          Dega=false;
           
        }
       
    }

}
