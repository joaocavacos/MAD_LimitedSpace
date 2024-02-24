using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrapCamera : MonoBehaviour
{

    public Transform cameraPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
