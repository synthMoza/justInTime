using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockScreen : MonoBehaviour
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
}
