using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNumberFalling : MonoBehaviour
{

    public AudioClip number;

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlayAudio(number);
    }
}
