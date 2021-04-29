using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    public Image icon;
    public Text textAmount;

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
    }
    
    public void ClearSlot()
    {
        item = null;

        textAmount.enabled = false;
        icon.sprite = null;
        icon.enabled = false;
    }
}
