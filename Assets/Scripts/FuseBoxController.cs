using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxController : MonoBehaviour
{
    private bool isOpened = false;
    [SerializeField]
    private MapController mapController;

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
        // change sprite
    }

    public void Switch()
    {
        mapController.TurnElectricityState();
        Debug.Log("Fuse box has been switched to state " + mapController.IsElectricityOn().ToString());
    }
}
