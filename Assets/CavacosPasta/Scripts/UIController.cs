using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : Singleton<UIController>
{
    public TMP_Text interactionText;
    public TMP_Text nameText;
    public Animator crosshairAnimator;
    
    public void SetDescriptionText(string text, float timeToDisappear = 0f)
    {
        interactionText.text = text;

        if (timeToDisappear > 0f)
        {
            StartCoroutine(TextDelay(timeToDisappear));
        }
    }
    
    public void SetNameText(string text, float timeToDisappear = 0f)
    {
        nameText.text = text;

        if (timeToDisappear > 0f)
        {
            StartCoroutine(TextDelay(timeToDisappear));
        }
    }

    public void ClearText()
    {
        interactionText.text = string.Empty;
        nameText.text = string.Empty;
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
