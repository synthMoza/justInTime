using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    private string currentCode;
    public string secretCode; // TODO: generate randomly?
    public UnityEvent onRightInput;

    public void ClearCode()
    {
        currentCode = "";
    }

    public void AddDigit(int digit)
    {
        if (digit >= 0 && digit <= 9)
            currentCode += digit.ToString();
    }

    public void CheckCode()
    {
        if (currentCode == secretCode)
        {
            onRightInput.Invoke();
        }

        ClearCode();
    }
}
