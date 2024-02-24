using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorManager : MonoBehaviour
{
    public Animator elevAnim;

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
        elevAnim.SetBool("isNear", true);
    }

}
