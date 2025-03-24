using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName = "Item/New Item")]
public class ItemData : ScriptableObject
{
    public string Nom;
    public string description;
    public Sprite Visual;
    public GameObject Prefab;
    public bool consomable;
    public bool stacable;
    public TypeEquipement typeEquipement;
    public float soins;
    public float pointArmure;
    public float dega;
    public float porter;
    public float degaguen;
    public float portergeun;
    public int valus;
    public int hemorragie;
    public int fracture;
    public int empoisonnement;
    


    


    public enum TypeEquipement
    {
        Casque,
        plastron,
        pentalon,
        Epee,
        guen
    }


}
