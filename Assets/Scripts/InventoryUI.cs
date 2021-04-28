using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    //public GameObject craftUI;
    
    private Inventory inventory;

    private InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instanse;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

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
        Item[] arrayOfInventoryItems = inventory.items.Keys.ToArray();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(arrayOfInventoryItems[i], inventory.items[arrayOfInventoryItems[i]]);
            }
        }
    }
}
