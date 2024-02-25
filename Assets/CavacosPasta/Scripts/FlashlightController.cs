using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Light _light;
    private bool isOn;

    public AudioClip flashlightSFX;
    
    void Start()
    {
        _light = GetComponent<Light>();
        isOn = _light.enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    private void ToggleFlashlight()
    {
        isOn = !isOn;
        _light.enabled = isOn;
        SoundManager.Instance.PlayAudio(flashlightSFX);
    }
}
