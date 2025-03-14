using UnityEngine;
using UnityEngine.UI;

public class BoutonObtion : MonoBehaviour
{ 
     [SerializeField] Button button;
    [SerializeField] GameObject gameObject;
    public void Option()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        button.Select();
    }
}
