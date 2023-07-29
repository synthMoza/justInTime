using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public bool hasCable;

    public void PickupCable()
    {
        Debug.Log("You just picked up some power cable!");
        hasCable = true;
    }
}
