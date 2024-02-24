using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{

    public Transform nextFloor;
    public GameObject previousFloor;


    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = nextFloor.transform.position;
        Destroy(previousFloor);

    }
}
