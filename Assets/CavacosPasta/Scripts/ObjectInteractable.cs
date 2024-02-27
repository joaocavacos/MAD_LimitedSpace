using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public string textToDisplay;

    public AudioClip paper;

    public UnityEvent OnEndofInteract;
    
    public void Interact()
    {
        UIController.Instance.ClearText();
        SoundManager.Instance.PlayAudio(paper);
        UIController.Instance.SetDescriptionText(textToDisplay, 2f);
        OnEndofInteract?.Invoke();
    }
    
}
