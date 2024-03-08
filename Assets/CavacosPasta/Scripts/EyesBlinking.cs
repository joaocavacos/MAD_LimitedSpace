using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesBlinking : MonoBehaviour
{
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();

        var randomSpeed = Random.Range(0.8f, 1.2f);
        _animator.speed = randomSpeed;
    }

    
}
