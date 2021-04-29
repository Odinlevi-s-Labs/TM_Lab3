using System;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSlot : MonoBehaviour
{
    public Image icon;

    public Recipe recipe;

    private void Start()
    {
        if (recipe != null)
        {
            icon.sprite = recipe.icon;
            icon.enabled = true;
        }
    }
        

    public void UseItem()
    {
        //Craft.instanse.ResetCraft();
        if (recipe != null)
            if (recipe.CanBeCrafted())
            {
                Craft.instanse.ProposeToCraft(recipe);
            }
            else
            {
                Craft.instanse.ShowIngredients(recipe);
            }
    }
    
    
}
