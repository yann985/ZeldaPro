using UnityEngine;
using TMPro;

public class AfichageArgent : MonoBehaviour
{
   [SerializeField] TMP_Text tMP_Text;

    // Update is called once per frame
    void Update()
    {
        tMP_Text.text = Inventaire.Instance.argent.ToString()+"€";
    }
}
