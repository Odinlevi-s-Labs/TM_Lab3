using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Craft/Recipe")]
public class Recipe : ScriptableObject
{
    public new string name = "New recipe";
    public Sprite icon = null;
    public Item item1;
    public Item item2;
    public int amount1;
    public int amount2;
    public Item resultItem;

    public virtual bool CanBeCrafted()
    {
        if (Inventory.instanse.items.ContainsKey(item1) && Inventory.instanse.items.ContainsKey(item2))
            if (Inventory.instanse.items[item1] >= amount1 && Inventory.instanse.items[item2] >= amount2)
                return true;
        return false;
    }
}
