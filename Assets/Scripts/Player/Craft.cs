using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    public static Craft instanse;
    
    public delegate void OnCraftChanged();
    
    public OnCraftChanged onCraftChangedCallback;
    
    public int space = 2;
    
    public Dictionary<Item, int> items = new Dictionary<Item, int>();
    public Item resultItem;
    public Recipe resultRecipe;
    
    private void Awake()
    {
        instanse = this;
        resultItem = null;
        resultRecipe = null;
    }

    public void ProposeToCraft(Recipe recipe)
    {
        if (recipe.CanBeCrafted() && Inventory.instanse.hasFreeSpace())
        {
            items[recipe.item1] = recipe.amount1;
            items[recipe.item2] = recipe.amount2;
            resultItem = recipe.resultItem;
            resultRecipe = recipe;
            
            onCraftChangedCallback?.Invoke();
            // Inventory.instanse.Remove(recipe.item1, recipe.amount1);
            // Inventory.instanse.Remove(recipe.item2, recipe.amount2);
        }
    }

    public void RunCraft(Recipe recipe)
    {
        if (recipe.CanBeCrafted() && Inventory.instanse.hasFreeSpace())
        {
            Inventory.instanse.Remove(recipe.item1, recipe.amount1);
            Inventory.instanse.Remove(recipe.item2, recipe.amount2);
            Inventory.instanse.Add(recipe.resultItem);
            
            ResetCraft();
            
            onCraftChangedCallback?.Invoke();
        }
    }

    public void ShowIngredients(Recipe recipe)
    {
        items[recipe.item1] = recipe.amount1;
        items[recipe.item2] = recipe.amount2;
        resultItem = recipe.resultItem;

        resultRecipe = recipe;
        
        onCraftChangedCallback?.Invoke();
    }

    public void ResetCraft()
    {
        items.Clear();
        resultItem = null;
        resultRecipe = null;
        
        onCraftChangedCallback?.Invoke();
    }
}
