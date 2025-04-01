using UnityEngine;
using UnityEngine.InputSystem;
public class Attaque : MonoBehaviour
{
    [SerializeField] Mouve mouve;
    [SerializeField] LayerMask layerMask;
    RaycastHit2D raycastResult;
    [SerializeField] float MaxDistance;
    public int forc;
    public bool BLocage = false;
    public float poinAttaqueEpee=1;
    public float hemorragie;  
    public float empoisonnement;
    public float fracture;
    public float poinPorteEpee=1;
    public float poinAttaqueGuen;
    public float poinPorteGuen;
    [SerializeField] AbtitudePlayer abtitudePlayer;

    [SerializeField] Animator animator;
    
   
    

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,mouve.directoFrape.normalized*MaxDistance,Color.red);
        animator.SetFloat("DirectionX",mouve.directoFrape.x);
        animator.SetFloat("DireectionY",mouve.directoFrape.y);
        if(Input.GetKey(KeyCode.I))
        {
            Debug.Log("teste18");
        }

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed && BLocage==false)
        {
            if(abtitudePlayer.Enduro>5)
                    {
                        if(raycastResult = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized, poinPorteEpee,layerMask))
           {

                if(raycastResult.transform.CompareTag("Truc"))
                {
                    
                    Monstre monstre = raycastResult.transform.GetComponent<Monstre>();
                    monstre.Dommages(poinAttaqueEpee+forc , hemorragie, fracture, empoisonnement);
                    animator.SetBool("CoupEpee", true);
                    
                }
           }
           abtitudePlayer.Enduro-=15;
                    }
           

        }
        
        
    }
    public void AttaqueLourde(InputAction.CallbackContext context)
    {
        if (context.performed && BLocage==false)
        {
            Debug.Log("Atta");
            if(abtitudePlayer.Enduro>10)
            {
                if(raycastResult = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized,poinPorteEpee,layerMask))
           {
                if(raycastResult.transform.CompareTag("Truc"))
                {
                    
                    Monstre monstre = raycastResult.transform.GetComponent<Monstre>();
                    monstre.Dommages(poinAttaqueEpee*2+forc ,hemorragie, fracture, empoisonnement);
                    animator.SetBool("CoupEpeeLour", true);
                }
           }
            abtitudePlayer.Enduro-=30;
            }

           
        }
        
        
    }
    public void Parade(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Parade");
           BLocage=true;
           animator.SetBool("Bouclier", BLocage);
        }
        if (context.canceled)
        {
            BLocage=false;
             animator.SetBool("Bouclier", BLocage);
        }
        
        
    }
    public void Guen(InputAction.CallbackContext context)
    {
        if (context.performed && BLocage==false)
        {
            Debug.Log("Gune");
           if(raycastResult = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized, poinPorteGuen,layerMask))
           {
                if(raycastResult.transform.CompareTag("Truc"))
                {
                    Monstre monstre = raycastResult.transform.GetComponent<Monstre>();
                    monstre.Dommages(poinAttaqueGuen,0,0,0);
                    
                    
                }
           }
           animator.SetBool("Pistol",true);
        }
        else
        {
            animator.SetBool("Pistol",false);
        }
    }
    public void finAttaque()
    {
        animator.SetBool("Pistol",false);
    }

    
}
