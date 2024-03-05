using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

public class CameraBobber : MonoBehaviour
{
    public float walkingBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;
    public PlayerController controller;

    private float defaultPosY = 0f;
    private float timer = 0f;
    
    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    void Update() 
    {
        if (controller.GetMovement()) //Check movement
        {
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x,
                defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else //Is idle
        {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed),
                transform.localPosition.z);
        }
    }
}
