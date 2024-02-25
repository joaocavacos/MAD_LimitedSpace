using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    private void OnEnable()
    {
        ItemPickable.OnItemPicked += AddItem;
    }

    private void OnDisable()
    {
        ItemPickable.OnItemPicked -= AddItem;
    }

    private void AddItem(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddQuantity();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
        }
        
        print("Added item: " + itemData.itemName);
    }

    public void RemoveItem(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveQuantity();

            if(item.quantity == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
        }
    }

    public InventoryItem GetItemByID(int ID)
    {
        return inventory.FirstOrDefault(item => item.itemData.itemID == ID);
    }

    public bool HasItemByData(ItemData data)
    {
        var hasData = false;
        
        foreach (var item in inventory.Where(item => item.itemData == data))
        {
            hasData = true;
        }

        return hasData;
    }
}
