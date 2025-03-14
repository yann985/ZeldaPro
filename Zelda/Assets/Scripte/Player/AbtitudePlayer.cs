using UnityEngine;

public class AbtitudePlayer : MonoBehaviour
{
    [SerializeField]Attaque attaque;
    public void Dommages(int dega)
    {
        if (attaque.BLocage==false)
        {
            Debug.Log("dega");
        }

        
    }
}
