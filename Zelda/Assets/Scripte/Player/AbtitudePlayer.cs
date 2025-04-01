
using UnityEngine;
using UnityEngine.InputSystem;

public class AbtitudePlayer : MonoBehaviour
{
    [SerializeField]Attaque attaque;
    [SerializeField] GameObject vieImage;
    [SerializeField] GameObject  EnduroImage;
    private Gamepad gamepad;
    public float vie=100;
    public float vieMax=100;
    public float Enduro=100;
    public float EnduroMax=100;
    public float pointArmure;
    float tempVibration;
    void Start()
    {
        gamepad = Gamepad.current;
    }



    void Update()
    {
       vieImage.transform.localScale=new Vector3(vie/vieMax,1,1); 
        if(Enduro<EnduroMax)
        {
            Enduro+=0.1f;
        }
        if( Enduro>0)
        {
            
            EnduroImage.transform.localScale=new Vector3(Enduro/EnduroMax,1,1);
        }
        else
        {
            Enduro=0;
            EnduroImage.transform.localScale=new Vector3(0/EnduroMax,1,1);
        }       
        if(vie>vieMax)
        {
            vie=vieMax;
        }
        if((tempVibration+=Time.deltaTime)>1 && gamepad!=null)
        {
            gamepad.SetMotorSpeeds(0,0);
            tempVibration=0;

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
            if(gamepad!=null)
            {
                gamepad.SetMotorSpeeds(0,1);
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
