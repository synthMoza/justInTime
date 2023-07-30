using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewable : MonoBehaviour
{
    private bool isActive;

    void Awake()
    {
        isActive = true;
    }

    public void ChangeActive()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        isActive = active;
    }
}
