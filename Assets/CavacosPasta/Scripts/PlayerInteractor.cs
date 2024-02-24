using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IInteractable _interactable;
    
    private void Update()
    {
        if (_interactable != null )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactable.Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering trigger");
        if (other.TryGetComponent(out IInteractable newInteractable))
        {
            _interactable = newInteractable;
            UIController.Instance.ChangeCrosshair("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _interactable = null;
        UIController.Instance.ChangeCrosshair("Open", false);
        UIController.Instance.ClearText();
    }
}
