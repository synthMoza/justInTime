using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField]
    private Sprite wardrobeOpen;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip openWardrobe;
    [SerializeField]
    private AudioClip pickUpCable;

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
            audioSource.PlayOneShot(openWardrobe);
        }
        else if (!isEmpty)
        {
            onInteraction.Invoke();
            audioSource.PlayOneShot(pickUpCable);
            isEmpty = true;
        }
    }
}
