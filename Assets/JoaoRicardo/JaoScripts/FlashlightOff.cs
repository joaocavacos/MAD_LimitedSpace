using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightOff : MonoBehaviour
{
    public GameObject lantern;

    private void OnTriggerEnter(Collider other)
    {
        lantern.SetActive(false);
    }
}
