using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public new string name = "New item";
    public Sprite icon = null;
    public int maximumInStack = 999;
    
    public virtual bool Use()
    {
        return true;
    }

}
