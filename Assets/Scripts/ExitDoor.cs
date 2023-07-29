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
        Debug.Log("The door has just been opened!");
    }

    public void TryEnter()
    {
        if (isOpen)
        {
            Debug.Log("You have just entered the door!");
            onEnterEvent.Invoke();
        }
        else
        {
            Debug.Log("The door is locked, you can't enter.");
        }
    }
}
