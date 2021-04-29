using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventory/Food")]
public class Food : Item
{
    public int hungerRefilling = 1;
    public override bool Use()
    {
        base.Use();
        
        Stats.instanse.IncreaseHunger(hungerRefilling);
        return Inventory.instanse.Remove(this);
    }
}
