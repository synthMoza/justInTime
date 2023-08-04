using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class RedButtonController : ButtonController
{
    [SerializeField]
    private TimeManager timeManager;
    private float timing = 96f; // todo: generate it

    void Start()
    {
        timing = PlayerPrefs.GetInt("red_button_timing", 0);
        if (timing == 0)
        {
            timing = Random.Range(80, 100);
            PlayerPrefs.SetInt("red_button_timing", (int) timing);
        }

        Debug.Log("timing is " + timing);
    }

    public override bool IsConditionTrue()
    {
        return timeManager.IsThisTime(timing);
    }
}
