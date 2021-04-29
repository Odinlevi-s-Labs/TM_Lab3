using UnityEditor.UIElements;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats instanse;

    public delegate void OnStatsChanged();
    public delegate void OnPlayerDeath();

    public OnStatsChanged onStatsChangedCallback;
    public OnPlayerDeath onPlayerDeathCallback;
    
    public int maxHealth = 20;
    public int currentHealth;
    public int maxHunger = 20;
    public int currentHunger;
    
    private float nextActionTime;
    private float timer;
    public int timePeriod = 20;
    
    private void Awake()
    {
        instanse = this;
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        nextActionTime = 0.0f;
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > nextActionTime)
        {
            nextActionTime += timePeriod;
            DecreaseHunger(1);
        }
        
    }

    public void IncreaseHealth(int amount=1)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        onStatsChangedCallback.Invoke();
    }
    
    public void DecreaseHealth(int amount=1)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onStatsChangedCallback.Invoke();
            onPlayerDeathCallback.Invoke();
        }
        else
        {
            onStatsChangedCallback.Invoke();
        }
    }

    public void IncreaseHunger(int amount=1)
    {
        currentHunger += amount;
        if (currentHunger > maxHunger)
            currentHunger = maxHunger;
        
        instanse.IncreaseHealth(1);
        
        onStatsChangedCallback.Invoke();
    }
    
    public void DecreaseHunger(int amount=1)
    {
        currentHunger -= amount;
        if (currentHunger <= 0)
        {
            currentHunger = 0;
            onStatsChangedCallback.Invoke();
            instanse.DecreaseHealth(1);
        }
        else
        {
            onStatsChangedCallback.Invoke();   
        }
    }
}
