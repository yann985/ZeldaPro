using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeNiveau : MonoBehaviour
{
    [SerializeField] SystemeSovegad systemeSovegad;
    [SerializeField] SistemeDeSovegardeInterMap sauvegardeIntermap;
    [SerializeField] GameObject player;
    bool zoneChangement;
    [SerializeField] int scene;
    [SerializeField] jestionPositionAparition jestionPositionAparition;
    [SerializeField] string NomX;
     [SerializeField] string NomY;
    void Start()
    {
        float X = PlayerPrefs.GetFloat(NomX,player.transform.position.x);
        float Y  = PlayerPrefs.GetFloat(NomY,player.transform.position.y);
        player.transform.position = new Vector2(X,Y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("player"))
        zoneChangement=true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(gameObject.CompareTag("player"))
        zoneChangement=false;
    } 
    public void Changement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            systemeSovegad.SaveData();
            sauvegardeIntermap.SaveData();
            SceneManager.LoadScene( scene );
            PlayerPrefs.SetFloat(NomX,player.transform.position.x);
            PlayerPrefs.SetFloat(NomY,player.transform.position.y);
        }
    }
}
