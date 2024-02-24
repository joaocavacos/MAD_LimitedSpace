using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : Singleton<UIController>
{
    public TMP_Text interactionText;
    public Animator crosshairAnimator;
    
    public void SetText(string text, float timeToDisappear = 0f)
    {
        interactionText.text = text;

        if (timeToDisappear > 0f)
        {
            StartCoroutine(TextDelay(timeToDisappear));
        }
    }

    public void ClearText()
    {
        interactionText.text = string.Empty;
    }

    public void ChangeCrosshair(string anim, bool state)
    {
        crosshairAnimator.SetBool(anim, state);
    }

    private IEnumerator TextDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearText();
    }
}
