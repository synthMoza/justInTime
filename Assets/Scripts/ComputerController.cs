using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField]
    private MapController mapController;
    [SerializeField]
    private Sprite computerOff;
    [SerializeField]
    private Sprite computerOn;

    public UnityEvent onAccesing;
    public UnityEvent onWrongAccesing;
    private bool isTurnedOn = false;

    private void ChangeSprite()
    {
        if (isTurnedOn)
            gameObject.GetComponent<SpriteRenderer>().sprite = computerOn;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = computerOff;
    }

    public void TrySetState(bool state)
    {
        isTurnedOn = state;
        ChangeSprite();
    }

    public void TryInteract(GameObject obj)
    {
        PlayerManager playerManager = obj.GetComponent<PlayerManager>();
        if (!playerManager)
        {
            Debug.Log("Wrong object to be interacted with computer");
            return;
        }

        // If the computer is turned off, check the cable
        if (!isTurnedOn)
        {
            if (playerManager.hasCable && mapController.IsElectricityOn())
            {
                Debug.Log("Computer has just been turned on");
                isTurnedOn = true;
                ChangeSprite();
            }
            else
            {
                Debug.Log("I can't use it right now");
                onWrongAccesing.Invoke();
            }
        }
        else // turned on
        {
            Debug.Log("Looks like there is something on the computer");
            onAccesing.Invoke();
        }
    }
}
