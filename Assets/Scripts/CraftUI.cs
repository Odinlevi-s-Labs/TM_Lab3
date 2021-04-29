using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject craftUI;
    //public GameObject inventoryUI;

    private Craft craft;
    
    private CraftSlot[] craftSlots;
    private ResultSlot resultSlot;
    private RecipeSlot[] recipeSlots;
    
    
    // Start is called before the first frame update
    void Start()
    {
        craft = Craft.instanse;
        craft.onCraftChangedCallback += UpdateUI;
        
        craftSlots = itemsParent.GetComponentsInChildren<CraftSlot>();
        resultSlot = itemsParent.GetComponentInChildren<ResultSlot>();
        recipeSlots = itemsParent.GetComponentsInChildren<RecipeSlot>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // if (!craftUI.activeSelf)
            // {
            //     inventoryUI.SetActive(true);
            //     craftUI.SetActive(true);
            // }
            // else
            // {
            //     craftUI.SetActive(false);
            // }
            craftUI.SetActive(!craftUI.activeSelf);
        }
    }
    
    void UpdateUI()
    {
        Item[] arrayOfCraftItems = craft.items.Keys.ToArray();
        
        for (int i = 0; i < craftSlots.Length; i++)
        {
            if (i < craft.items.Count)
            {
                craftSlots[i].AddItem(arrayOfCraftItems[i], craft.items[arrayOfCraftItems[i]]);
            }
            else
            {
                craftSlots[i].ClearSlot();
            }
        }

        foreach (var slot in recipeSlots)
        {
            if (slot.recipe != null && slot.recipe.CanBeCrafted())
            {
                var color = slot.icon.color;
                color.a = 256;
                slot.icon.color = color;
            }
            else
            {
                var color = slot.icon.color;
                color.a = 128;
                slot.icon.color = color;
            }
        }

        if (craft.resultRecipe != null)
        {
            resultSlot.AddResult(craft.resultRecipe);
        }
        else
        {
            resultSlot.ClearSlot();
        }
    }
}
