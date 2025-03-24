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

    [SerializeField] Animator animator;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,mouve.directoFrape.normalized*MaxDistance,Color.red);
        animator.SetFloat("DirectionX",mouve.directoFrape.x);
        animator.SetFloat("DireectionY",mouve.directoFrape.y);

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed && BLocage==false)
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
        }
        
        
    }
    public void AttaqueLourde(InputAction.CallbackContext context)
    {
        if (context.performed && BLocage==false)
        {
            Debug.Log("Atta");
           if(raycastResult = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized,poinPorteEpee,layerMask))
           {
                if(raycastResult.transform.CompareTag("Truc"))
                {
                    
                    Monstre monstre = raycastResult.transform.GetComponent<Monstre>();
                    monstre.Dommages(poinAttaqueEpee*2+forc ,hemorragie, fracture, empoisonnement);
                    animator.SetBool("CoupEpeeLour", true);
                }
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
                    animator.SetBool("Pistol",true);
                    
                }
           }
        }
    }
    public void finAttaque()
    {
        animator.SetBool("Pistol",false);
    }

    
}
