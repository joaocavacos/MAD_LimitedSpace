using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public string textToDisplay;
    public AudioClip interactSound;
    public UnityEvent OnEndofInteract;
    
    public void Interact()
    {
        UIController.Instance.ClearText();
        UIController.Instance.SetDescriptionText(textToDisplay, 2f);
        if(interactSound != null) SoundManager.Instance.PlayAudio(interactSound);
        OnEndofInteract?.Invoke();
    }

    public void DestroyInteraction()
    {
        Destroy(this);
    }
    
}
