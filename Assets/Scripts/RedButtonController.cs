using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class RedButtonController : ButtonController
{
    [SerializeField]
    private TimeManager timeManager;
    private float timing = 96f; // todo: generate it

    public override bool IsConditionTrue()
    {
        return timeManager.IsThisTime(timing);
    }
}
