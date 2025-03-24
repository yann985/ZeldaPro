using UnityEngine;
using UnityEngine.InputSystem;

public class RamacerItem : MonoBehaviour
{
    [SerializeField] Mouve mouve;
    [SerializeField] LayerMask layerMask;
    
    [SerializeField] float MaxDistance;
    RaycastHit2D hit;
    [SerializeField] RamacerManadjeur ramacerItem;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(hit = Physics2D.Raycast(transform.position,mouve.directoFrape.normalized, MaxDistance*2,layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                
                ramacerItem.AddItem(hit.transform.gameObject.GetComponent<Item>());
                
                Destroy(hit.transform.gameObject);

            }
        }
        }
        
        
    }
}
