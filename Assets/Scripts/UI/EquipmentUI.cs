using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject equipmentUI;
    //public GameObject craftUI;
    
    //private Inventory inventory;

    private EquipmentSlot slot;

    // Start is called before the first frame update
    void Start()
    {
        //inventory = Inventory.instanse;
        Equipment.instanse.onEquipmentChangedCallback += UpdateUI;

        slot = itemsParent.GetComponentInChildren<EquipmentSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            equipmentUI.SetActive(!equipmentUI.activeSelf);

            /*
             if (!inventoryUI.activeSelf)
            {
                craftUI.SetActive(false);
            }
            */
        }
    }
    
    void UpdateUI()
    {
        if (Equipment.instanse.item != null)
            slot.AddItem(Equipment.instanse.item);
        else
        {
            slot.ClearSlot();
        }

        Inventory.instanse.onItemChangedCallback.Invoke();
    }
}
