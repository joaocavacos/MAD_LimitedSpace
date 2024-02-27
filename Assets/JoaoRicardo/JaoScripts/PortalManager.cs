using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalManager : MonoBehaviour
{
    public Transform nextFloor;
    public GameObject previousFloor;
    public Animator elevatorAnim;

    public AudioClip elevator;

    public UnityEvent OnElevatorEnter;
    public UnityEvent OnElevatorStop;


    private void OnTriggerEnter(Collider other)
    {
        
        StartCoroutine(ElevatorCoroutine(other));
        //other.transform.rotation = rot;
    }

    private IEnumerator ElevatorCoroutine(Collider player)
    {
        GameDirector.Instance.ChangeGameState(false);
        elevatorAnim.SetBool("isNear", false);
        if(elevator != null) SoundManager.Instance.PlayAudio(elevator);
        yield return new WaitForSeconds(2f);
        OnElevatorEnter?.Invoke();
        yield return new WaitForSeconds(0.1f);
        player.transform.position = nextFloor.transform.position;
        yield return new WaitForSeconds(2f);
        OnElevatorStop?.Invoke();
        GameDirector.Instance.ChangeGameState(true);
        Destroy(previousFloor);
    }
}
