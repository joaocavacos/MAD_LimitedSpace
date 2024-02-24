using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorManager : MonoBehaviour
{
    public Animator elevAnim;

    private void OnTriggerEnter(Collider other)
    {
        elevAnim.SetBool("isNear", true);
    }

    public void OpenElevator()
    {
        elevAnim.SetBool("isNear", true);
    }

    private void OnTriggerExit(Collider other)
    {
        elevAnim.SetBool("isNear", false);
    }

}
