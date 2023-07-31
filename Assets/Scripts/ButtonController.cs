using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public UnityEvent onTrueCondition;
    public UnityEvent onWrongCondition;

    public virtual bool IsConditionTrue()
    {
        return true;
    }

    public void TryPress()
    {
        if (IsConditionTrue())
            onTrueCondition.Invoke();
        else
            onWrongCondition.Invoke();
    }
}
