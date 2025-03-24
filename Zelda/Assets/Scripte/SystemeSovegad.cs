using System;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class SystemeSovegad : MonoBehaviour
{
  [ SerializeField] Transform PlayerTransform;
  [ SerializeField] AbtitudePlayer abtitudePlayer;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            Recharge();
        }

    }

    private void Recharge()
    {
        string filePach = Application.persistentDataPath+"/Savdata.jiSon";
        string jsonData = System.IO.File.ReadAllText(filePach);
        SavedData savedData = JsonUtility.FromJson<SavedData>(jsonData);
        PlayerTransform.transform.position= savedData.pausitionPlayer;
        Inventaire.Instance.ChargeEquipement(new ItemData []{savedData.casqueEquipe,savedData.plastronEquipe,savedData.pantalonEquipe,savedData.epeeEquipe,savedData.gunEquipe});
        Inventaire.Instance.ReachargeData(savedData.invenroriItemDatas);
        abtitudePlayer.vie = savedData.vie;

    }

    private void SaveData()
    {
        SavedData savedData = new SavedData
        {
            pausitionPlayer=PlayerTransform.position,
            invenroriItemDatas = Inventaire.Instance.contenu, 
            casqueEquipe = Inventaire.Instance.casqueEquipe,
            plastronEquipe = Inventaire.Instance.plastronEquipe,
            pantalonEquipe = Inventaire.Instance.pantalonEquipe,
            epeeEquipe = Inventaire.Instance.epeeEquipe,
            gunEquipe = Inventaire.Instance.gunEquipe,
            vie= abtitudePlayer.vie

        };
        string jsonData = JsonUtility.ToJson(savedData);
        string filePach = Application.persistentDataPath+"/Savdata.jiSon";
        Debug.Log(filePach);
        System.IO.File.WriteAllText(filePach,jsonData);
       
    }
}
class SavedData
{
    public Vector3 pausitionPlayer;
    public List<InvenroriItemData> invenroriItemDatas;
    public ItemData casqueEquipe, plastronEquipe, pantalonEquipe, epeeEquipe, gunEquipe;
    public float vie;
    
}
