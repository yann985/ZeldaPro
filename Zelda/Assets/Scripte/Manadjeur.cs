using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manadjeur : MonoBehaviour
{
    public static Manadjeur Instance;

    public bool traduction=false;

        void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        Instance=this;
       

    } 


}
