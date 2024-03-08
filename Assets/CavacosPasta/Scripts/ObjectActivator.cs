using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectActivator : MonoBehaviour
{
    public List<ItemData> neededItems;
    private int itemsListSize;
        
    public UnityEvent OnActivateObject;

    public void VerifyActivation()
    {
        var inventory = Inventory.Instance.inventory;
        itemsListSize = neededItems.Count;
        var sizeCount = 0;
        print("Inventory count: " + inventory.Count);
        print("Needed items count: " + neededItems.Count);
        
        for (var i = 0; i < inventory.Count; i++)
        {
            for (var j = 0; j < neededItems.Count; j++)
            {
                print("inventory item data: " + inventory[i].itemData);
                print("needed items item data: " + neededItems[j]);
                if (inventory[i].itemData == neededItems[j])
                {
                    sizeCount++;
                }
            }
        }
        
        print("Size count: " + sizeCount + " | Needed items List Size: " + itemsListSize);
        
        if (sizeCount < itemsListSize) return;
        
        OnActivateObject?.Invoke();
    }

    public void ActivateObject()
    {
        print("Object activated");
    }
}
