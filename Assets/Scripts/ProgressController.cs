using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    private bool isElectricityOn = false;

    public void TurnElectricityState()
    {
        isElectricityOn = !isElectricityOn;
        // TODO: handle lights
    }

    public bool IsElectricityOn()
    {
        return isElectricityOn;
    }
}
