using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isGamePaused = false; // is pause menu on the screen
    public static bool isPhysicsPaused = false; // is player frozen
    
    public UnityEvent onPauseAction;
    public UnityEvent onUnpauseAction;
    public KeyCode pauseKey;

    public void ChangeGamePause()
    {
        isGamePaused = !isGamePaused;
        ChangePhysicsPause();

        if (isGamePaused)
            onPauseAction.Invoke();
        else
            onUnpauseAction.Invoke();
    }

    public void ChangePhysicsPause()
    {
        isPhysicsPaused = !isPhysicsPaused;
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
            ChangeGamePause();
    }
}
