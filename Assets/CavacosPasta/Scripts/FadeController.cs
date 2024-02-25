using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void StopPlayer()
    {
        GameDirector.Instance.ChangeGameState(false);
    }

    public void ResumePlayer()
    {
        GameDirector.Instance.ChangeGameState(true);
    }
    
    public void FadeOutEnding()
    {
        GameDirector.Instance.EndGame();
    }

    public void FadeOut()
    {
        _animator.SetBool("FadeOut", true);
    }
    
}
