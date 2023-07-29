using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    private bool isOpen;
    private bool isEmpty;
    public UnityEvent onInteraction;

    public void Interact()
    {
        if (!isOpen)
        {
            Debug.Log("The wardrobe has been opened!");
            isOpen = true;
        }
        else if (!isEmpty)
        {
            onInteraction.Invoke();
            isEmpty = true;
        }
    }
}
