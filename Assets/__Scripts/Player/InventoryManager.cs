using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SerializedMonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private Dictionary<ItemData, int> _itemsInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (_itemsInventory == null) _itemsInventory = new Dictionary<ItemData, int>();
    }

    public void AddItem(ItemData itemData)
    {
        if (_itemsInventory.ContainsKey(itemData))
        {
            _itemsInventory[itemData] += 1;
            print($"added existing item, item: {itemData.Name}");
            return;
        }
        print($"added new item, item: {itemData.Name}");
        _itemsInventory.Add(itemData,1);
    }
    public void RemoveItem(ItemData itemData) 
    {
        if (_itemsInventory[itemData] == 1)
        {
            _itemsInventory.Remove(itemData);
            print($"removed last item, item: {itemData.Name}");
            return;
        }
        print($"removed item, item: {itemData.Name}");
        _itemsInventory[itemData] -= 1;
    }
}
