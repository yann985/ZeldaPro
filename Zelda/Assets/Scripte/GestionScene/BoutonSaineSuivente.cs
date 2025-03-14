using UnityEngine;
using UnityEngine.SceneManagement;
public class BoutonSaineSuivente : MonoBehaviour
{
    [SerializeField] int Scene;
    public  void next()
   {
     Time.timeScale=1;
        SceneManager.LoadScene(Scene);
   }
}
