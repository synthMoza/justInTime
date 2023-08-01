using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxController : MonoBehaviour
{
    private bool isOpened = false;
    
    [SerializeField]
    private MapController mapController;

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
        // change sprite
    }

    public void Switch()
    {
        mapController.TurnElectricityState();
        audioSource.PlayOneShot(onSwitchFusebox);
        Debug.Log("Fuse box has been switched to state " + mapController.IsElectricityOn().ToString());
    }
}
