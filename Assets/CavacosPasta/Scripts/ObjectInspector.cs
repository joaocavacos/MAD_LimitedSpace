using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObjectInspector : StaticInstance<ObjectInspector>, IDragHandler
{
    private GameObject inspectGO;
    public float rotationSpeed;
    public UnityEvent OnInspectClose;
    
    public void OnDrag(PointerEventData eventData)
    {
        inspectGO.transform.eulerAngles += new Vector3(eventData.delta.y, -eventData.delta.x) * rotationSpeed;
    }

    public void SetGameObjectInspect(GameObject go)
    {
        inspectGO = go;
    }

    public void CloseInspect()
    {
        OnInspectClose?.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(inspectGO);
    }

}
