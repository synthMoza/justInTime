using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField]
    private Sprite wardrobeOpen;

    private bool isOpen;
    private bool isEmpty;
    public UnityEvent onInteraction;

    public void Interact()
    {
        if (!isOpen)
        {
            Debug.Log("The wardrobe has been opened!");
            isOpen = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = wardrobeOpen;
        }
        else if (!isEmpty)
        {
            onInteraction.Invoke();
            isEmpty = true;
        }
    }
}
