using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class RedButtonController : MonoBehaviour
{
    private float timing = 96f; // todo: generate it
    public UnityEvent onCorrectTiming;
    public UnityEvent onWrongTiming;

    public void TryPress(GameObject obj)
    {
        TimeManager timer = obj.GetComponent<TimeManager>();
        if (!timer)
        {
            Debug.Log("Can't try to press red button with this object");
            return;
        }

        if (timer.IsThisTime(timing))
            onCorrectTiming.Invoke();
        else
            onWrongTiming.Invoke();
    }
}
