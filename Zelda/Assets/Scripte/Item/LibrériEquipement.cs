using System.Collections.Generic;
using UnityEngine;

public class LibrériEquipement : MonoBehaviour
{
public List<LibreriEquipementItem> content = new List<LibreriEquipementItem>();    

}
[System.Serializable]
public class LibreriEquipementItem
{
    public ItemData itemData;
    public GameObject itemPrefab;
}
