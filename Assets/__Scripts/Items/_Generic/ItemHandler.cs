using System.Collections;
using UnityEngine;


public class ItemHandler
{
    private void AddStatItem(StatItemData itemData)
    {
        foreach (var kvp in itemData.Stats)
        {
            Stat key = kvp.Key;
            float value = kvp.Value;

            StatsManager.PlayerStats.AddStatValue(key, value);
        }
    }
    private void RemoveStatItem(StatItemData itemData)
    {
        foreach (var kvp in itemData.Stats)
        {
            Stat key = kvp.Key;
            float value = kvp.Value;

            StatsManager.PlayerStats.ReduceStatValue(key, value);
        }
    }
    
    public void AddItem(ItemData itemData)
    {
        switch (itemData.Type) 
        {
            case ItemType.StatItem:
                AddStatItem((StatItemData)itemData);
                break;
        }
    }
    public void RemoveItem(ItemData itemData) 
    {
        switch (itemData.Type)
        {
            case ItemType.StatItem:
                RemoveStatItem((StatItemData)itemData);
                break;
        }
    }
}
