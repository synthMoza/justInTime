using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public KeyCode pauseButton;
    public UnityEvent onClick;

    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
            onClick.Invoke();
    }
}
