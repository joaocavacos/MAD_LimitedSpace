using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public string textToDisplay;

    public UnityEvent OnEndofInteract;
    
    public void Interact()
    {
        UIController.Instance.SetDescriptionText(textToDisplay);
        OnEndofInteract?.Invoke();
    }
    
}
