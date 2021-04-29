using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResultSlot : MonoBehaviour
{
    public Image icon;
    public Button resultCraftButton;
    public Button removeButton;
    
    //private Item _item;
    public Recipe recipe;

    public void AddResult(Recipe newRecipe)
    {
        recipe = newRecipe;

        icon.sprite = recipe.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        resultCraftButton.interactable = recipe.CanBeCrafted();
    }

    public void ClearSlot()
    {
        recipe = null;

        icon.sprite = null;
        icon.enabled = false;
        resultCraftButton.interactable = true;
        removeButton.interactable = false;
    }

    // public void SetResultButtonState(bool isInteractable)
    // {
    //     resultCraftButton.interactable = isInteractable;
    // }

    public void OnRemoveButton()
    {
        Craft.instanse.ResetCraft();
        ClearSlot();
    }

    public void RunCraft()
    {
        if (recipe != null)
        {
            Craft.instanse.RunCraft(recipe);
            ClearSlot();
        }
    }
}
