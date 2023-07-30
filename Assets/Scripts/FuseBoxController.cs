using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxController : MonoBehaviour
{
    [SerializeField]
    private MapController mapController;

    public void Switch()
    {
        mapController.TurnElectricityState();
        Debug.Log("Fuse box has been switched to state " + mapController.IsElectricityOn().ToString());
    }
}
