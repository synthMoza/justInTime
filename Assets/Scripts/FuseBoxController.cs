using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxController : MonoBehaviour
{
    private bool isOpened = false;
    
    [SerializeField]
    private MapController mapController;
    
    [SerializeField]
    private Sprite turnedOffSprite;
    [SerializeField]
    private Sprite turnedOnSprite;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip onOpenFusebox;
    [SerializeField]
    private AudioClip onSwitchFusebox;

    public void Interact()
    {
        if (isOpened)
            Switch();
        else
            Open();
    }

    private void Open()
    {
        isOpened = true;
        audioSource.PlayOneShot(onOpenFusebox);
        gameObject.GetComponent<SpriteRenderer>().sprite = turnedOffSprite;
    }

    public void Switch()
    {
        mapController.TurnElectricityState();
        audioSource.PlayOneShot(onSwitchFusebox);
        
        if (mapController.IsElectricityOn())
            gameObject.GetComponent<SpriteRenderer>().sprite = turnedOnSprite;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = turnedOffSprite;

        Debug.Log("Fuse box has been switched to state " + mapController.IsElectricityOn().ToString());
    }
}
