using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonDeTrensition : MonoBehaviour
{
  public  void traduction()
   {
    Manadjeur.Instance.traduction = !Manadjeur.Instance.traduction;
   }
    public  void next()
   {
        SceneManager.LoadScene(1);
   }

}
