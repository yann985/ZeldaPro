using UnityEngine;

public class Monstre : MonoBehaviour
{
    [SerializeField] private Attaque attaque;  // Référence au joueur
    [SerializeField] private float HP = 100f;  // Points de vie du monstre
    [SerializeField] private float speed = 2f; // Vitesse de déplacement
    [SerializeField] private float maxDistance = 10f; // Distance maximale du Raycast
    [SerializeField] private LayerMask layerMask; // Masque de collision pour le Raycast
    bool dectetion;
     private float Cadace=5;
    

    
    void Update()
    {
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
                    AbtitudePlayer abtitudePlayer = raycastResult.transform.GetComponent<AbtitudePlayer>();
                    abtitudePlayer.Dommages(10);
                    Debug.Log("contact");
                    Cadace=0;
                }
            
           }
          
    }

    public void Dommages(int degats)
    {
        HP -= degats;
        Debug.Log($"HP du monstre: {HP}");
        if (HP <= 0)
        {
            Destroy(gameObject); // Détruit l'ennemi quand il n'a plus de vie
        }
    }
    
}
