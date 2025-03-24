using UnityEngine;

public class XP : MonoBehaviour
{
     [SerializeField] GameObject  BarXP;
    public float XPTotal;
    [SerializeField]private float XPMax = 20;
    [SerializeField]private float XPDuNiveaux ;
    public float poinDeConpetance;
    //Public int Niveaux;


  

    // Update is called once per frame
    void Update()
    {
        Progration();
    }
    void Progration()
    {
        XPDuNiveaux=XPTotal;
    BarXP.transform.localScale=new Vector3(XPDuNiveaux/XPMax,1,1);
        if(  XPDuNiveaux >= XPMax )
        {
            XPTotal-=XPMax;
            XPMax*=2;
            poinDeConpetance++;
            if(XPTotal == 0)
            {
                XPTotal = 1;
            }

        }
    }
}
