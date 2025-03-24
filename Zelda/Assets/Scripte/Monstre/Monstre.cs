using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Monstre : MonoBehaviour
{
    [SerializeField] private Attaque attaque;  // Référence au joueur
    [SerializeField] private float HP = 100f;  // Points de vie du monstre
    [SerializeField] private float speed = 2f; // Vitesse de déplacement
    [SerializeField] private int frape = 10;
    [SerializeField] private float maxDistance = 10f; // Distance maximale du Raycast
    [SerializeField] private LayerMask layerMask; // Masque de collision pour le Raycast
    [SerializeField] private int XPGagnier;
    [SerializeField] private XP xP;
    [SerializeField] private int sensibilitehemorragie;
    [SerializeField] private int sensibiliteFracture;
    [SerializeField] private int sensibiliteEmpoisonement;
    [SerializeField] private List<GameObject> gameObjects;

    private bool activeEmpoisonement;
    private bool activeHemoragi;
    private bool activeFractur;


    bool dectetion;
     private float Cadace=5;
    

    
    void Update()
    {
        if(activeEmpoisonement)
        {
            HP-=0.05f;
        }
        if(activeFractur)
        {
            speed = speed/2;
        }
        // Direction vers le joueur
        Vector2 direction = (attaque.transform.position - transform.position).normalized;
        float distance=Vector2.Distance(transform.position,attaque.transform.position);
        // Raycast pour détecter le joueur
        RaycastHit2D raycastResult = Physics2D.Raycast(transform.position, direction, maxDistance, layerMask);

        // Affichage du Raycast dans la scène pour le debug
        Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
        if(distance<10 )
        {
            dectetion=true;
            
        }
        if(distance>20)
        {
            dectetion=false;
        }
        if(dectetion==true && distance>2)
        {
            transform.position=Vector2.MoveTowards(transform.position,attaque.transform.position,speed*Time.deltaTime);
        }



        if(raycastResult && (Cadace+=Time.deltaTime)>5 )
           {
                if(raycastResult.transform.CompareTag("player"))
                {
                    if(activeHemoragi)
                    {
                        HP -= HP/20;
                    }
                     if(activeFractur)
                    {
                        frape = frape/2;
                    }
                    AbtitudePlayer abtitudePlayer = raycastResult.transform.GetComponent<AbtitudePlayer>();
                    abtitudePlayer.Dommages(frape);
                    
                    Cadace=0;
                }
            
           }
          
    }

    public void Dommages(float degats, float hemorragie, float fracture, float empoisonnement )
    {
        HP -= degats;
       
       
        if (HP <= 0)
        {
            Destroy(gameObject); // Détruit l'ennemi quand il n'a plus de vie
            Inventaire.Instance.argent+= Random.Range(1,50);
            xP.XPTotal+=XPGagnier;
            if(gameObjects.Count>0)
            {
                Debug.Log("drop");
                int Drop=Random.Range(0,gameObjects.Count);
                Instantiate(gameObjects[Drop],transform.position,transform.rotation);
            }
            

        }
        if ( hemorragie >=Random.Range( 0,sensibilitehemorragie) )
        {
            activeHemoragi=true;
        }
        if ( hemorragie >=Random.Range( 0,sensibiliteFracture) )
        {
            activeFractur=true;
        }
        if ( hemorragie >=Random.Range( 0,sensibiliteEmpoisonement) )
        {
            activeEmpoisonement=true;
        }
    }
    
}
