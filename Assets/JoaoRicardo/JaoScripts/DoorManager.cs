using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator doorAnim;
    public AudioClip doorCreek;
    private bool _canOpen = true;
    
    public void OpenDoor()
    {
        if (!_canOpen) return;
        doorAnim.SetBool("shouldOpen", true);
        SoundManager.Instance.PlayAudio(doorCreek);
        _canOpen = false;
    }
    
    


}
