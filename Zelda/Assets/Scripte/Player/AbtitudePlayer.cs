using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class AbtitudePlayer : MonoBehaviour
{
    [SerializeField]Attaque attaque;
    [SerializeField] GameObject vieImage;
     [SerializeField] GameObject  EnduroImage;
    public float vie=100;
    float vieMax=100;
    public float Enduro=100;
    float EnduroMax=100;
    public float
 pointArmure;
  


    void Update()
    {
        EnduroImage.transform.localScale=new Vector3(Enduro/EnduroMax,1,1);
        if(Enduro<EnduroMax)
        {
            Enduro++;
        }
        vieImage.transform.localScale=new Vector3(vie/vieMax,1,1);
        if(vie>vieMax)
        {
            vie=vieMax;
        }
    }
    public void Dommages(int dega)
    {
        if (attaque.BLocage==false)
        {
            vie-=dega*(1-(pointArmure/100));
            
            if(vie<=0)
            {
                Destroy(this.gameObject);
            }
            
        }

        
    }
     public void EnduroConter(int Consomation)
    {
        if (attaque.BLocage==false)
        {
            Enduro-=Consomation;
            
            
        }

        
    }
    public void ConsomeItem(float soins)
    {
        vie+=soins;
        
        Debug.Log(soins);
    }
    //  public void Dommages(int dega)
    // {
    //     if (attaque.BLocage==false)
    //     {
    //         transform.localScale=new Vector3(vie/vieMax,1,1);
            
    //     }

        
    // }
}
