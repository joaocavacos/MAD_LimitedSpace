using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUserInteraction : MonoBehaviour, IInteractable
{
    public ItemData neededItem;
    
    public void Interact()
    {
        if (Inventory.Instance.HasItemByData(neededItem))
        {
            UIController.Instance.SetText("Unlocked the fucking cube");
        }
        else
        {
            UIController.Instance.SetText("You don't have the fucking key");
        }
    }
}
