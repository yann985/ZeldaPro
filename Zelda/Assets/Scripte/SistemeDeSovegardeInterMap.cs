using System.Collections.Generic;
using UnityEngine;

public class SistemeDeSovegardeInterMap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
[ SerializeField] Transform PlayerTransform;
  [ SerializeField] AbtitudePlayer abtitudePlayer;
  [ SerializeField] Attaque attaque;
  [ SerializeField] XP xP;
    public void Recharge()
    {
        string filePach = Application.persistentDataPath+"/Savdata.jiSonInvaantair";
        string jsonData = System.IO.File.ReadAllText(filePach);
        SavedData savedData = JsonUtility.FromJson<SavedData>(jsonData);
        PlayerTransform.transform.position= savedData.pausitionPlayer;
        Inventaire.Instance.ChargeEquipement(new ItemData []{savedData.casqueEquipe,savedData.plastronEquipe,savedData.pantalonEquipe,savedData.epeeEquipe,savedData.gunEquipe});
        Inventaire.Instance.ReachargeData(savedData.invenroriItemDatas);
        abtitudePlayer.vie = savedData.vie;
        abtitudePlayer.vieMax = savedData.vieMax;
        abtitudePlayer.Enduro = savedData.enduro;
        abtitudePlayer.EnduroMax = savedData.enduroMax;
        attaque.forc = savedData.forc;
        attaque.hemorragie = savedData.hemorragie;
        attaque.empoisonnement = savedData.empoisonnement;
        attaque.fracture = savedData.fracture;
        xP.XPTotal = savedData.XPTotal;
        xP.poinDeConpetance = savedData.poinDeConpetance;
        Inventaire.Instance.argent = savedData.argent;


    }

    public void SaveData()
    {
        SavedData savedData = new SavedData
        {
            
            invenroriItemDatas = Inventaire.Instance.contenu, 
            casqueEquipe = Inventaire.Instance.casqueEquipe,
            plastronEquipe = Inventaire.Instance.plastronEquipe,
            pantalonEquipe = Inventaire.Instance.pantalonEquipe,
            epeeEquipe = Inventaire.Instance.epeeEquipe,
            gunEquipe = Inventaire.Instance.gunEquipe,
            vie= abtitudePlayer.vie,
            vieMax =  abtitudePlayer.vieMax,
            forc = attaque.forc,
            hemorragie = attaque.hemorragie,
            empoisonnement = attaque.empoisonnement ,
            fracture = attaque.fracture,
            enduro = abtitudePlayer.Enduro,
            enduroMax = abtitudePlayer.EnduroMax,
            XPTotal = xP.XPTotal,
            poinDeConpetance = xP.poinDeConpetance,
            argent = Inventaire.Instance.argent 
            

        };
        string jsonData = JsonUtility.ToJson(savedData);
        string filePach = Application.persistentDataPath+"/Savdata.jiSonInvaantai";
        Debug.Log(filePach);
        System.IO.File.WriteAllText(filePach,jsonData);
       
    }
}
class SavedDataInvantaire
{
    
    public List<InvenroriItemData> invenroriItemDatas;
    
    public ItemData casqueEquipe, plastronEquipe, pantalonEquipe, epeeEquipe, gunEquipe;
    public float vie;
    public float vieMax;
    public int forc;
    public float hemorragie;  
    public float empoisonnement;
    public float fracture;
    public float enduro;
    public float enduroMax;
    public float XPTotal;
     public float poinDeConpetance;
     public int argent;
    
}


