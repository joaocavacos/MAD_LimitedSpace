using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemUserInteraction : MonoBehaviour, IInteractable
{
    public ItemData neededItem;
    public string UnlockMessage;
    public string LockedMessage;
    public UnityEvent OnItemUnlock;
    public AudioClip fuse;
    
    public void Interact()
    {
        UIController.Instance.ClearText();
        if (Inventory.Instance.HasItemByData(neededItem))
        {
            SoundManager.Instance.PlayAudio(fuse);
            UIController.Instance.SetDescriptionText(UnlockMessage, 2f);
            OnItemUnlock?.Invoke();
        }
        else
        {
            UIController.Instance.SetDescriptionText(LockedMessage, 2f);
        }
    }
}
