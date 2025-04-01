using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    [SerializeField] private GameObject panelInventaire;
     public List<InvenroriItemData> contenu = new List<InvenroriItemData>();
    [SerializeField] private Transform inventaireParentSlot;
    
    private const int TailleInventaire = 81;
    
    [SerializeField] private Button boutonPrincipal;
    [SerializeField] private EventSystem eventSystem;
    
    public static Inventaire Instance { get; private set; }

    private ItemData itemSelectionne;
    
    [SerializeField] private LibrériEquipement librerieEquipement;
    [SerializeField] private Image casque, plastron, pantalon, epee, gun;
    
    public ItemData casqueEquipe, plastronEquipe, pantalonEquipe, epeeEquipe, gunEquipe;
    
    [SerializeField] private Button boutonTete, boutonCorps, boutonJambes, boutonArme, boutonPistolet;
    public Sprite fond;
    [SerializeField] private AbtitudePlayer abtitudePlayer;

    public  TriguerDescription descriptionItem;
    [SerializeField] private Attaque attaque;
    ItemData iteme;
    public int argent;
    public bool marchan;
    

    private void Awake()
    {
        Instance = this;
    }

    public void AjouterItem(ItemData item)
    {
        if (item == null) return;

        
        InvenroriItemData itemExistant = contenu.FirstOrDefault(i => i.itemData == item);
        
        if (itemExistant != null)
        {
            itemExistant.stoc++;
        }
        else if (!InventairePlein())
        {
            contenu.Add(new InvenroriItemData { itemData = item, stoc = 1 });
        }
        else
        {
            Debug.LogWarning("Inventaire plein !");
            return;
        }

        RafraichirContenu();
    }

    public void AfficherPanelInventaire(InputAction.CallbackContext context)
    {
        panelInventaire.SetActive(!panelInventaire.activeSelf);
        
        if (panelInventaire.activeSelf)
        {
            boutonPrincipal.Select();
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void RafraichirContenu()
    {
        for (int i = 0; i < contenu.Count; i++)
        {
            descriptionItem = inventaireParentSlot.GetChild(i).GetComponent<TriguerDescription>();
            descriptionItem.item = contenu[i].itemData;
            descriptionItem.visual.sprite = contenu[i].itemData.Visual;
            descriptionItem.Text.text=contenu[i].stoc.ToString();
        }
        

        Debug.Log(descriptionItem?.item);
        MettreAJourBoutonsDesequipement();
    }

    public bool InventairePlein()
    {
        return contenu.Count >= TailleInventaire;
    }

    public void EquiperItem(TriguerDescription triguerDescription=null)
    {
        
        ItemData ItemEquope= iteme ? iteme : triguerDescription.item ; 
        Debug.Log(ItemEquope);
        if(!ItemEquope)
        {
            Debug.Log("vide");
            return;
        }
        if(marchan)
        {
            if(ItemEquope.valus>argent)
            {
                return;
            }
            Debug.Log("comerce");
            argent+=ItemEquope.valus;
            RetirerItem(ItemEquope);
            ItemEquope=null;
            RafraichirContenu();
            for (int i = 0; i < contenu.Count; i++)
        {
            
            triguerDescription.stoc=contenu[i].stoc; 
        }
            if( triguerDescription.stoc <=1)
            {
               triguerDescription.item=null;
            }
            
            return;
        }
      if (ItemEquope.consomable)
      {
          abtitudePlayer.ConsomeItem(ItemEquope.soins);
          Debug.Log(ItemEquope.soins);
          RetirerItem(ItemEquope);
      }
      if(!ItemEquope.consomable)
      {
        itemSelectionne = ItemEquope;

        if (itemSelectionne == null) return;

        LibreriEquipementItem equipementItem = librerieEquipement.content.FirstOrDefault(elm => elm.itemData == itemSelectionne);

        if (equipementItem != null)
        {
            equipementItem.itemPrefab.SetActive(true);

            switch (itemSelectionne.typeEquipement)
            {
                case ItemData.TypeEquipement.Casque:
                    ChangementEquipement(ref casqueEquipe, casque, itemSelectionne);
                    break;
                case ItemData.TypeEquipement.plastron:
                    ChangementEquipement(ref plastronEquipe, plastron, itemSelectionne);
                    break;
                case ItemData.TypeEquipement.pentalon:
                    ChangementEquipement(ref pantalonEquipe, pantalon, itemSelectionne);
                    break;
                case ItemData.TypeEquipement.Epee:
                    ChangementEquipement(ref epeeEquipe, epee, itemSelectionne);
                    break;
                case ItemData.TypeEquipement.guen:
                    ChangementEquipement(ref gunEquipe, gun, itemSelectionne);
                    break;
            }
        }
        else
        {
            Debug.LogError("Équipement introuvable !");
        }
        
        abtitudePlayer.pointArmure+=ItemEquope.pointArmure;
        attaque.poinAttaqueEpee+=ItemEquope.dega;
        attaque.empoisonnement+=ItemEquope.empoisonnement;
        attaque.hemorragie+=ItemEquope.hemorragie;
        attaque.fracture+=ItemEquope.fracture;
        attaque.poinPorteEpee+=ItemEquope.porter;
        attaque.poinAttaqueGuen+=ItemEquope.degaguen;
        attaque.poinPorteGuen+=ItemEquope.portergeun;


        RetirerItem(ItemEquope);
         ItemEquope=null;
        RafraichirContenu();
        
      }
      if(triguerDescription!=null)
      {
        triguerDescription.item=null;
      }
      
      RafraichirContenu();
    }

    private void MettreAJourBoutonsDesequipement()
    {
        boutonTete.onClick.RemoveAllListeners();
        boutonTete.onClick.AddListener(() => DesequiperItem(ItemData.TypeEquipement.Casque));

        boutonCorps.onClick.RemoveAllListeners();
        boutonCorps.onClick.AddListener(() => DesequiperItem(ItemData.TypeEquipement.plastron));

        boutonJambes.onClick.RemoveAllListeners();
        boutonJambes.onClick.AddListener(() => DesequiperItem(ItemData.TypeEquipement.pentalon));

        boutonArme.onClick.RemoveAllListeners();
        boutonArme.onClick.AddListener(() => DesequiperItem(ItemData.TypeEquipement.Epee));

        boutonPistolet.onClick.RemoveAllListeners();
        boutonPistolet.onClick.AddListener(() => DesequiperItem(ItemData.TypeEquipement.guen));
    }

    public void DesequiperItem(ItemData.TypeEquipement typeEquipement)
    {
        ItemData item = null;

        switch (typeEquipement)
        {
            case ItemData.TypeEquipement.Casque:
                item = casqueEquipe;
                casqueEquipe = null;
                casque.sprite = null;
                break;
            case ItemData.TypeEquipement.plastron:
                item = plastronEquipe;
                plastronEquipe = null;
                plastron.sprite = null;
                break;
            case ItemData.TypeEquipement.pentalon:
                item = pantalonEquipe;
                pantalonEquipe = null;
                pantalon.sprite = null;
                break;
            case ItemData.TypeEquipement.Epee:
                item = epeeEquipe;
                epeeEquipe = null;
                epee.sprite = null;
                break;
            case ItemData.TypeEquipement.guen:
                item = gunEquipe;
                gunEquipe = null;
                gun.sprite = null;
                break;
        }

        if (item != null)
        {
            LibreriEquipementItem equipementItem = librerieEquipement.content.FirstOrDefault(elm => elm.itemData == item);
            if (equipementItem != null)
            {
                equipementItem.itemPrefab.SetActive(false);
            }
        }
        if(item)
        {
            attaque.poinAttaqueEpee-=item.dega;
        attaque.poinPorteEpee-=item.porter;
          attaque.empoisonnement-=item.empoisonnement;
        attaque.hemorragie-=item.hemorragie;
        attaque.fracture-=item.fracture;
        attaque.poinAttaqueGuen-=item.degaguen;
        attaque.poinPorteGuen-=item.portergeun;
        abtitudePlayer.pointArmure-=item.pointArmure;
        }
        
        AjouterItem(item);
        RafraichirContenu();
    }

    private void ChangementEquipement(ref ItemData equipementActuel, Image slotImage, ItemData nouvelEquipement)
    {
        if (equipementActuel != null)
        {
            AjouterItem(equipementActuel);
        }

        slotImage.sprite = nouvelEquipement.Visual;
        equipementActuel = nouvelEquipement;
    }

    private void RetirerItem(ItemData item)
    {
        InvenroriItemData itemExistant = contenu.FirstOrDefault(i => i.itemData == item);
        if (itemExistant != null)
        {
            itemExistant.stoc--;
            if (itemExistant.stoc <= 0)
            {
                contenu.Remove(itemExistant);
            }
        }
    }

    public void ReachargeData(List<InvenroriItemData>saveData)
    {
        contenu=saveData;
        RafraichirContenu();
    }
    
       
    
    public void ChargeEquipement(ItemData[] itemDatas)
    {
         contenu.Clear();
        foreach(ItemData.TypeEquipement type in System.Enum.GetValues(typeof(ItemData.TypeEquipement)))
        {

            DesequiperItem(type);
        }
        foreach(ItemData item in itemDatas)
        {
            if(item)
            {
                iteme=item;
                EquiperItem(null);

            }
            
        }
    }
}

[System.Serializable]
    public class InvenroriItemData
    {
        public ItemData itemData;
        public int stoc;
    }
