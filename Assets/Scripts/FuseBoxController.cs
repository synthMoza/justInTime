using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxController : MonoBehaviour
{
    [SerializeField]
    private ProgressController progressController;

    public void Switch()
    {
        progressController.TurnElectricityState();
        Debug.Log("Fuse box has been switched to state " + progressController.IsElectricityOn().ToString());
    }
}
