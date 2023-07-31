using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    [SerializeField]
    private ExitDoor exitDoor;

    Dictionary<string, bool> buttonsStates = new Dictionary<string, bool>()
    {
        {"red", false},
        {"green", false},
        {"blue", true}
    };

    public void SetButtonState(string button)
    {
        if (!buttonsStates.ContainsKey(button))
        {
            Debug.Log("Wrong button name in buttons controller");
            return;
        }

        buttonsStates[button] = true;
        if (buttonsStates["red"] && buttonsStates["green"] && buttonsStates["blue"])
            exitDoor.SetCanBeOpened();
    }

    void Update()
    {
        
    }
}
