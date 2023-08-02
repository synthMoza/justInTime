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
    private Sprite leftWindowLightSprite2;
    
    [SerializeField]
    private GameObject leftWindowLight;
    [SerializeField]
    private GameObject rightWindowLight;

    [SerializeField]
    private ComputerController computer;

    [SerializeField]
    private GameObject neonArrow;

    public void TurnElectricityState()
    {
        isElectricityOn = !isElectricityOn;
        if (isElectricityOn)
        {
            // controll shadows
            lowerShadow.SetActive(false);
            upperLeftShadow.SetActive(false);
            upperRightShadow.SetActive(false);
        }
        else
        {
            // control shadows
            lowerShadow.SetActive(true);
            upperLeftShadow.SetActive(!isLeftCurtainOpen);
            upperRightShadow.SetActive(!isRightCurtainOpen);

            // handle electric stuff
            computer.TrySetState(false);
        }

        // hint on second button
        neonArrow.SetActive(!isLeftCurtainOpen && !isElectricityOn);
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
        
        // hint on second button
        neonArrow.SetActive(!isLeftCurtainOpen && !isElectricityOn);
    }

    public void ChangeLeftWindowLightSprite()
    {
        leftWindowLight.GetComponent<SpriteRenderer>().sprite = leftWindowLightSprite2;
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
