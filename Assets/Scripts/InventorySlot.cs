using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
    
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text textAmount;
    public Button removeButton;
    
    private Item item;

    public void AddItem(Item newItem, int amount)
    {
        item = newItem;

        if (amount > 1)
            textAmount.text = amount.ToString();
        else
        {
            textAmount.text = null;
        }

        textAmount.enabled = true;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        textAmount.text = null;
        textAmount.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        bool shouldSlotBeCleared = Inventory.instanse.Remove(item);
        if (shouldSlotBeCleared)
            ClearSlot();
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
