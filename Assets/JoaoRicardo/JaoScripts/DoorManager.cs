using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator doorAnim;

    private void OnTriggerEnter(Collider other)
    {
        doorAnim.SetBool("shouldOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        doorAnim.SetBool("shouldOpen", false);
    }

}
