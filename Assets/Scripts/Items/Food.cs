using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventory/Food")]
public class Food : Item
{
    public int hungerRefilling = 1;
    public override bool Use()
    {
        base.Use();
        Debug.Log("Should refill " + hungerRefilling + " hunger");
        return Inventory.instanse.Remove(this);
    }
}
