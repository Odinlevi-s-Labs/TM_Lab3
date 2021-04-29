using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public int damage = 1;
    
    public override bool Use()
    {
        base.Use();
        Debug.Log("Should equip " + this.name + "");
        
        return Inventory.instanse.Remove(this);
    }
}
