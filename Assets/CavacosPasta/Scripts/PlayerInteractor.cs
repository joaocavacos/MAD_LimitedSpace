using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IInteractable _interactable;
    
    public float rayDistance;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var interactionRay = _camera.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
        
        Debug.DrawRay(interactionRay.origin, interactionRay.direction * rayDistance);

        if (Physics.Raycast(interactionRay.origin, interactionRay.direction * rayDistance, out var hit, rayDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable newInteractable))
            {
                //print("Raycast hit: " + hit.collider.name);
                _interactable = newInteractable;
                UIController.Instance.ChangeCrosshair("Open", true);
            }
        }
        else
        {
            _interactable = null;
            UIController.Instance.ChangeCrosshair("Open", false);
        }

        if (_interactable != null && Input.GetKeyDown(KeyCode.E) && GameDirector.Instance.canPlay)
        {
            _interactable.Interact();
        }
    }

}
