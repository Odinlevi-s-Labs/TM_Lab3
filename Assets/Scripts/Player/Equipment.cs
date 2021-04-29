using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public static Equipment instanse;
    
    public delegate void OnEquipmentChanged();
    public OnEquipmentChanged onEquipmentChangedCallback;

    public Weapon item;
    
    private void Awake()
    {
        instanse = this;
    }

    public bool Add(Weapon weapon)
    {
        if (!Inventory.instanse.Remove(weapon))
        {
            return false;
        }

        if (item != null)
        {
            Inventory.instanse.Add(item);
        }
        
        item = weapon;

        onEquipmentChangedCallback.Invoke();
        
        return true;
    }

    public void Remove()
    {
        if (Inventory.instanse.hasFreeSpace())
        {
            Inventory.instanse.Add(item);
            item = null;
            
            onEquipmentChangedCallback.Invoke();
            //return true;
        }
        //return false;
    }
}
