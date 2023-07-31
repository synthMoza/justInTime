using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField]
    private Sprite openDoorSprite;

    public UnityEvent onWrongAccessing;
    public UnityEvent onEnterEvent;

    private bool isOpen = false;
    private bool canbeOpened = false;

    public void SetCanBeOpened()
    {
        canbeOpened = true;
    }

    public void Open()
    {
        Debug.Log("The door has just been opened!");
        
        isOpen = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = openDoorSprite;
        onEnterEvent.Invoke(); // consider is in range
    }

    public void Interact()
    {
        if (canbeOpened)
            Open();
        else
            onWrongAccessing.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isOpen)
            onEnterEvent.Invoke();
    }
}
