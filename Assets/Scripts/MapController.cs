using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private bool isElectricityOn = false;
    private bool isLeftCurtainOpen = true;
    private bool isRightCurtainOpen = true;

    [SerializeField]
    private GameObject lowerShadow;
    [SerializeField]
    private GameObject upperLeftShadow;
    [SerializeField]
    private GameObject upperRightShadow;

    [SerializeField]
    private GameObject leftWindowLight;
    [SerializeField]
    private GameObject rightWindowLight;

    public void TurnElectricityState()
    {
        isElectricityOn = !isElectricityOn;
        if (isElectricityOn)
        {
            lowerShadow.SetActive(false);
            upperLeftShadow.SetActive(false);
            upperRightShadow.SetActive(false);
        }
        else
        {
            lowerShadow.SetActive(true);
            upperLeftShadow.SetActive(!isLeftCurtainOpen);
            upperRightShadow.SetActive(!isRightCurtainOpen);
        }
    }

    public bool IsElectricityOn()
    {
        return isElectricityOn;
    }

    public void ChangeLeftWindowState()
    {
        isLeftCurtainOpen = !isLeftCurtainOpen;
        leftWindowLight.SetActive(isLeftCurtainOpen);
        upperLeftShadow.SetActive(!isLeftCurtainOpen && !isElectricityOn);
    }

    public void ChangeRightWindowState()
    {
        isRightCurtainOpen = !isRightCurtainOpen;
        rightWindowLight.SetActive(isRightCurtainOpen);
        upperRightShadow.SetActive(!isRightCurtainOpen && !isElectricityOn);
    }

    public bool IsLightsOff()
    {
        return !isRightCurtainOpen && !isLeftCurtainOpen && !isElectricityOn;
    }
}
