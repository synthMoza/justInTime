using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float currentTime;
    private bool isClockTicking = true;
    public float gameTimeout;
    
    public Text timerText;
    public UnityEvent onTimePassed;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private float timeWhenTickingStarts = 20f;
    [SerializeField]
    private AudioClip clockTickingClip;
    private bool wasTickingLaunched = false;

    void Start()
    {
        currentTime = gameTimeout;
    }

    void Update()
    {   
        if (isClockTicking)
        {
            currentTime -= Time.unscaledDeltaTime;
            int minutes = (int) currentTime / 60;
            int seconds = (int) currentTime - minutes * 60;
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            
            if (currentTime <= timeWhenTickingStarts && !wasTickingLaunched)
            {
                audioSource.PlayOneShot(clockTickingClip);
                wasTickingLaunched = true;
                timerText.color = Color.red;
            }

            if (currentTime <= 0)
            {
                // Time has passed, trigger the event and disable the clock
                isClockTicking = false;
                currentTime = 0;

                StopTickingClip();
                onTimePassed.Invoke();
            }
        }
    }

    public void StopTickingClip()
    {
        audioSource.Stop();
    }

    public bool IsThisTime(float checkTiming)
    {
        return (int) currentTime == (int) checkTiming;
    }

    public void StopTimer()
    {
        isClockTicking = false;
        wasTickingLaunched = false;
        audioSource.Stop();
    }

    public void ContinueTimer()
    {
        isClockTicking = true;
    }
}
