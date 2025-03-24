using UnityEngine;

public class DescriptionMessage : MonoBehaviour
{
    public static DescriptionMessage instanc;
    [SerializeField]private Description description;

    void Awake()
    {
        instanc=this;
    }
    public void Visible(string non ,string escription)
    {
        
        description.gameObject.SetActive(true);
        description.SetText(non, escription);
        
    }
    public void Cacher()
    {
        
        description.gameObject.SetActive(false);

    }
}
