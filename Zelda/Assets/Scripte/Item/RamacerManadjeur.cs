using System.Collections.Generic;
using UnityEngine;

public class RamacerManadjeur : MonoBehaviour
{
    [SerializeField] private Inventaire invanter;
    public void AddItem(Item item)
    {
        if (invanter.InventairePlein())
        {
            return;
        }
       invanter.AjouterItem(item.item);
    }
    
}
