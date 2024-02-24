using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour, IInteractable
{
    public delegate void HandleItemPicked(ItemData data);
    public static event HandleItemPicked OnItemPicked;

    public ItemData itemData;
    //public string Name => itemData.itemName;
    public string displayText;

    public void Interact()
    {
        Destroy(gameObject);
        UIController.Instance.SetText(displayText, 2f);
        UIController.Instance.ChangeCrosshair("Open", false);
        OnItemPicked?.Invoke(itemData);
    }
}
