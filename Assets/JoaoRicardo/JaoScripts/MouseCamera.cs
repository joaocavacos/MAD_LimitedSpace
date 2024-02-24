using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float sensX = 0f;
    public float sensY = 0f;

    public Transform orientation;

    float xRot = 0f;
    float yRot = 0f;

    public float cameraZoomSpeed;
    public float minZoomAmount;
    private Camera _camera;
    private float defaultZoom;
    private float wheelAxis;
    

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        defaultZoom = _camera.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;
        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0f);
        orientation.rotation = Quaternion.Euler(0, yRot, 0f);
        
        HandleZoom();
    }

    private void HandleZoom()
    {
        if (_camera.orthographic) return;
        
        wheelAxis = Input.GetAxis("Mouse ScrollWheel");
        _camera.fieldOfView -= wheelAxis * cameraZoomSpeed * Time.deltaTime;
        
        //Debug.Log("Camera FOV: " + _camera.fieldOfView + " | Axis Value: " + Input.GetAxis("Mouse ScrollWheel"));

        if (_camera.fieldOfView < minZoomAmount)
        {
            _camera.fieldOfView = minZoomAmount;
        }
        else if (_camera.fieldOfView > defaultZoom)
        {
            _camera.fieldOfView = defaultZoom;
        }
    }
}
