using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{

    public Transform nextFloor;
    public GameObject previousFloor;

    private Quaternion rot = Quaternion.Euler(0f, 180f, 0f);


    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = nextFloor.transform.position;
        other.transform.rotation = rot;
        Destroy(previousFloor);

    }
}
