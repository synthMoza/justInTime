using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButtonController : ButtonController
{
    [SerializeField]
    private MapController mapController;

    public override bool IsConditionTrue()
    {
        return mapController.IsLightsOff();
    }
}
