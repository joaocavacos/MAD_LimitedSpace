using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent OnTriggerEvent;
    [Header("If you want to trigger an audio clip insert it here")]
    public AudioClip audioClip;
    [Header("If you want to trigger a text insert it here")]
    public string triggerText;

    public float messageDuration = 2f;
    
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEvent?.Invoke();
        Destroy(gameObject);
    }

    public void PlaySound()
    {
        SoundManager.Instance.PlayAudio(audioClip);
    }

    public void ShowText()
    {
        UIController.Instance.SetDescriptionText(triggerText, messageDuration);
    }
}
