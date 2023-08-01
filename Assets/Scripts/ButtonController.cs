using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public UnityEvent onTrueCondition;
    public UnityEvent onWrongCondition;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip buttonClickClip;

    public virtual bool IsConditionTrue()
    {
        return true;
    }

    public void TryPress()
    {
        audioSource.PlayOneShot(buttonClickClip);
        if (IsConditionTrue())
            onTrueCondition.Invoke();
        else
            onWrongCondition.Invoke();
    }
}
