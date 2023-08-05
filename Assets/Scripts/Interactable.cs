using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey = KeyCode.E;
    public UnityEvent interactAction;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey) && !PauseManager.isGamePaused)
            interactAction.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = false;
    }
}
