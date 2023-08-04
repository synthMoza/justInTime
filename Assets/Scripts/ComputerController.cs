using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField]
    private HintsManager hintsManager;
    [SerializeField]
    private DiaryController diaryController;

    [SerializeField]
    private MapController mapController;
    [SerializeField]
    private Sprite computerOff;
    [SerializeField]
    private Sprite computerOn;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip computerTurnOnClip;
    [SerializeField]
    private AudioClip computerClickClip;

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
                isTurnedOn = true;
                ChangeSprite();
                audioSource.PlayOneShot(computerTurnOnClip);
                Debug.Log("Computer has just been turned on");
            }
            else
            {
                Debug.Log("I can't use it right now");
                hintsManager.ShowHint("I can't turn it on, this computer is not conected to the network.");
            }
        }
        else // turned on
        {
            Debug.Log("Looks like there is something on the computer");
            audioSource.PlayOneShot(computerClickClip);

            string fileName = PlayerPrefs.GetString("safe_secret_code") + ".txt";
            hintsManager.ShowHint("Hm, there is an interesting file " + fileName + " on the desktop, what is it about?");
            diaryController.AddNote("One can find file " + fileName + " on the desktop");
        }
    }
}
