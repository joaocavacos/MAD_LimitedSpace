using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlickeringLights : MonoBehaviour
{
    private Light myLight;

    float interval = 1;
    float timer;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            myLight.enabled = !myLight.enabled;
            interval = Random.Range(0f, 1f);
            timer = 0;
        }
    }
}
