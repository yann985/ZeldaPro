using UnityEngine;

public class JenCharle : MonoBehaviour
{
    public Monstre monstre;
    [SerializeField] Mouve mouve;
    public bool dectetion ;
    bool retour;
    bool suivit;
    [SerializeField] float speed;
    [SerializeField] LayerMask layerMask;
    float maxDistance = 4;
    float Cadace;
    public int puissance;
    RaycastHit2D raycastResult;
    float distance;
    [SerializeField] Animator animator;

    [SerializeField] Rigidbody2D rigidbody2D;
    Vector2 sence;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==7)
        {
            monstre=collision.gameObject.GetComponent<Monstre>();
        }
    }
    void Update()
    {
        if(rigidbody2D.linearVelocity!=Vector2.zero)
        {
            sence = rigidbody2D.linearVelocity;
        }
        
        animator.SetFloat("X",sence.x);
        animator.SetFloat("Y", sence.y);
        if(monstre==null)
        {
            dectetion=false;
        }
        if(monstre!=null)
        {
            Vector2 direction = (monstre.transform.position - transform.position).normalized;
            raycastResult = Physics2D.Raycast(transform.position, direction, maxDistance, layerMask);
            Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
            distance=Vector2.Distance(transform.position,monstre.transform.position);
         if(distance<10 )
        {
            dectetion=true;
            
        }
        if(distance>20)
        {
            dectetion=false;
        }

        }
        
        
     
        float distanceMetre = Vector2.Distance(transform.position , mouve.transform.position);
        // Raycast pour détecter le joueur
       
         if (distanceMetre>40)
         {
            retour=true;
            suivit=true;
         }
         if(distanceMetre>2)
         {
            suivit=true;
         }
         if(distanceMetre<2)
         {
            suivit=false;
            retour=false;
            rigidbody2D.linearVelocity=Vector2.zero;
         }
         
        
        if(retour)
        {
            rigidbody2D.linearVelocity = (mouve.transform.position - transform.position).normalized*speed;
            Debug.Log("attaque1");
            monstre=null;
        }
        else if(suivit && !dectetion)
        {
            rigidbody2D.linearVelocity = (mouve.transform.position - transform.position).normalized*speed;
            Debug.Log("attaque2");
        }
        else if(distance<2)
        {
            
            rigidbody2D.linearVelocity=Vector2.zero;
            Debug.Log("attaque3");

        }
        else if(dectetion && distance>2 && monstre!=null)
        {
            rigidbody2D.linearVelocity = (monstre.transform.position - transform.position).normalized*speed;
            Debug.Log("attaque4");
            
        }
        

        if(raycastResult && (Cadace+=Time.deltaTime)>5 )
           {
                if(raycastResult.transform.CompareTag("Truc"))
                {
                    
                    monstre.Dommages( puissance,0,0,0);
                    
                    
                    
                    Cadace=0;
                }
           }
          
    }
}
