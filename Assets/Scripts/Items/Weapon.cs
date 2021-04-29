using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public int damage = 1;
    
    public override bool Use()
    {
        base.Use();
        var success = Equipment.instanse.Add(this);
        
        if (success)
            Debug.Log(this.name+" was equipped.");
        else
            Debug.Log(this.name+" wasn't equipped.");
        
        return true;
    }
}
