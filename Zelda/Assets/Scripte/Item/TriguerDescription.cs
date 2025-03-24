using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class TriguerDescription : MonoBehaviour
{
    [SerializeField] Button button;
    public Image visual;
        public TMP_Text Text;
    public ItemData item;
    [SerializeField] Description description;
    
    // Update is called once per frame
    void Update()
    {
        
        
        if (item!=null)
        {
            if (EventSystem.current.currentSelectedGameObject == button.gameObject)
        {
            
            DescriptionMessage.instanc.Visible(item.Nom, item.description);
            description.transform.position=transform.position-new Vector3(0,200);

        }
        else if (EventSystem.current.currentSelectedGameObject == button.gameObject)
        {
            
            DescriptionMessage.instanc.Cacher();
        }
        
        }
        if(item==null)
        {
            visual=null;
        }
       
    }
}
