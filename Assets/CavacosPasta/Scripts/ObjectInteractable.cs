using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractable
{
    public string textToDisplay;
    
    public void Interact()
    {
        UIController.Instance.SetDescriptionText(textToDisplay);
    }
    
}
