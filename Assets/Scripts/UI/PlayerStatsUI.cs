using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public Slider HealthBar;
    public Slider HungerBar;
    
    
    
    void Start()
    {
        HealthBar.maxValue = Stats.instanse.maxHealth;
        HungerBar.maxValue = Stats.instanse.maxHunger;
        HealthBar.minValue = 0;
        HungerBar.minValue = 0;
        
        //inventory = Inventory.instanse;
        Stats.instanse.onStatsChangedCallback += UpdateUI;

        
    }

    void UpdateUI()
    {
        HealthBar.value = Stats.instanse.currentHealth;
        HungerBar.value = Stats.instanse.currentHunger;
    }
}
