using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float currentTime;
    private bool isClockTicking;
    public float gameTimeout;
    
    public Text timerText;
    public UnityEvent onTimePassed;

    void Start()
    {
        isClockTicking = true;
        currentTime = gameTimeout;
    }

    void Update()
    {   
        if (isClockTicking)
        {
            currentTime -= Time.deltaTime;
            int minutes = (int) currentTime / 60;
            int seconds = (int) currentTime - minutes * 60;
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            
            if (currentTime <= 0)
            {
                // Time has passed, trigger the event and disable the clock
                isClockTicking = false;
                onTimePassed.Invoke();
            }
        }
    }
}
