using UnityEngine;
using UnityEngine.UI;
public class BoutonSelecte : MonoBehaviour
{
    
    [SerializeField] Button button;
    
    void Start()
    {
        button.Select();
    }

    
}
