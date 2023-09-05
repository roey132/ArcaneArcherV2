using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SerializedMonoBehaviour
{
    public static InventoryManager Instance;


    [SerializeField] private Dictionary<ItemData, GameObject> _itemsInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (_itemsInventory == null) _itemsInventory = new Dictionary<ItemData, GameObject>();
    }

    public void AddItem(ItemData itemData)
    {
        _itemsInventory.Add(itemData,itemData.itemObject);
    }
    public void RemoveItem(ItemData itemData) 
    {
        _itemsInventory.Remove(itemData);
    }
}
