using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ItemPickable : MonoBehaviour, IInteractable
{
    public delegate void HandleItemPicked(ItemData data);
    public static event HandleItemPicked OnItemPicked;

    public ItemData itemData;
    public string Name => itemData.itemName;
    public string displayText;
    [Header("Inspect Properties")]
    public bool isInspectable = false;
    public GameObject itemPrefab;
    private GameObject itemGO;
    private Vector3 inspectCamPos = new Vector3(1000,1000,1000);
    public UnityEvent OnItemInspect;
    public UnityEvent OnItemPickUnityEvent;

    public void Interact()
    {
        UIController.Instance.SetNameText(Name, 5f);
        UIController.Instance.SetDescriptionText(displayText, 5f);
        UIController.Instance.ChangeCrosshair("Open", false);
        OnItemPicked?.Invoke(itemData);
        OnItemPickUnityEvent?.Invoke();
        
        if (isInspectable)
        {
            Inspect();
            GameDirector.Instance.ChangeGameState(false);
        }
        
        Destroy(gameObject);
    }

    private void Inspect()
    {
        OnItemInspect?.Invoke();
        Cursor.lockState = CursorLockMode.None;
        itemGO = Instantiate(itemPrefab, inspectCamPos, Quaternion.identity);
        ObjectInspector.Instance.SetGameObjectInspect(itemGO);
    }
}
