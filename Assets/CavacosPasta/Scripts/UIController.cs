using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : Singleton<UIController>
{
    public TMP_Text interactionText;
    public Animator crosshairAnimator;

    public void SetText(string text)
    {
        interactionText.text = text;
    }

    public void ClearText()
    {
        interactionText.text = string.Empty;
    }

    public void ChangeCrosshair(string anim, bool state)
    {
        crosshairAnimator.SetBool(anim, state);
    }
}
