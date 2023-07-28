using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public UnityEvent onEnterEvent;
    private bool isOpen;

    public void Open()
    {
        isOpen = true;
    }

    public void TryEnter()
    {
        if (isOpen)
            onEnterEvent.Invoke();
    }
}
