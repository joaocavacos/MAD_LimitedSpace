using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator doorAnim;
    public AudioClip doorkCreek;

    private void OnTriggerEnter(Collider other)
    {
        doorAnim.SetBool("shouldOpen", true);
        SoundManager.Instance.PlayAudio(doorkCreek);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnim.SetBool("shouldOpen", false);
    }

}
