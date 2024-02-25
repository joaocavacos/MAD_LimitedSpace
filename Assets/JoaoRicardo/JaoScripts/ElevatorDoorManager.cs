using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorManager : MonoBehaviour
{
    public Animator elevAnim;
    public AudioClip ding;

    private void OnTriggerEnter(Collider other)
    {
        OpenElevator();
    }

    private void OnTriggerExit(Collider other)
    {
        elevAnim.SetBool("isNear", false);
    }
    
    public void OpenElevator()
    {
        SoundManager.Instance.PlayAudio(ding);
        elevAnim.SetBool("isNear", true);
    }

}
