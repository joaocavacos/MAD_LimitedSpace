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
        if (Inventory.Instance.HasItemByData(neededItem))
        {
            SoundManager.Instance.PlayAudio(fuse);
            UIController.Instance.SetDescriptionText(UnlockMessage);
            OnItemUnlock?.Invoke();
        }
        else
        {
            UIController.Instance.SetDescriptionText(LockedMessage);
        }
    }
}
