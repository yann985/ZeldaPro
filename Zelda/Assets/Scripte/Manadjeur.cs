using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manadjeur : MonoBehaviour
{
    public static Manadjeur instance;

    public int traduction=0;
   public bool DialogueStarte;
        
        private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        Time.timeScale=1;
    }





}
