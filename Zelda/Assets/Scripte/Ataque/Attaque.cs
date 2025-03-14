using UnityEngine;
using UnityEngine.InputSystem;
public class Attaque : MonoBehaviour
{
    [SerializeField] Mouve mouve;
    [SerializeField] LayerMask layerMask;
    RaycastHit2D raycastResult;
    [SerializeField] float MaxDistance;
    public bool BLocage = false;
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
           if(raycastResult = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized, MaxDistance,layerMask))
           {
                if(raycastResult.transform.CompareTag("Truc"))
                {
                    Monstre monstre = raycastResult.transform.GetComponent<Monstre>();
                    monstre.Dommages(10);
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
           if(raycastResult = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized, MaxDistance,layerMask))
           {
                if(raycastResult.transform.CompareTag("Truc"))
                {
                    
                    Monstre monstre = raycastResult.transform.GetComponent<Monstre>();
                    monstre.Dommages(10*2);
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
           if(raycastResult = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized, MaxDistance*2,layerMask))
           {
                if(raycastResult.transform.CompareTag("Truc"))
                {
                    Monstre monstre = raycastResult.transform.GetComponent<Monstre>();
                    monstre.Dommages(10*4);
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
