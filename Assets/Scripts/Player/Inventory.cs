using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instanse;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public int space = 20;
    
    public Dictionary<Item, int> items = new Dictionary<Item, int>();

    private void Awake()
    {
        instanse = this;
    }

    public bool Add(Item item, int amount=1)
    {
        if (!items.ContainsKey(item))
            if (items.Count < space)
            {
                items.Add(item, amount);
                onItemChangedCallback?.Invoke();
                return true;
            }
            else
            {
                Debug.Log("Not enough room in the inventory");
                return false;
            }
        else
        {
            if (items[item] + amount <= item.maximumInStack)
            {
                items[item] += amount;
                onItemChangedCallback?.Invoke();
                return true;
            }
            else if (items[item] < item.maximumInStack)
            {
                items[item] = item.maximumInStack;
                onItemChangedCallback?.Invoke();
                Debug.Log("Can't have more than that in (one stack/inventory)");
                return true;
            }
            else
            {
                Debug.Log("Already maximum in the (one stack/inventory)");
                return false;
            }
        }
    }

    public bool Remove(Item item, int amount = 1)
    {
        // Return true if item should be removed from inventory and false if only a small amount is removed

        if (!items.ContainsKey(item))
            return false;
        
        if (items[item] <= amount)
        {
            items.Remove(item);
            onItemChangedCallback?.Invoke();
            return true;
        }
        else
        {
            items[item] -= amount;
            onItemChangedCallback?.Invoke();
            return false;
        }
        
    }

    public bool hasFreeSpace()
    {
        if (Inventory.instanse.items.Count < space)
            return true;
        return false;
    }
}
