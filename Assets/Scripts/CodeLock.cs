using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    private string currentCode;
    public string secretCode; // TODO: generate randomly?
    public UnityEvent onRightInput;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip correctInputClip;
    [SerializeField]
    private AudioClip wrongInputClip;
    [SerializeField]
    private AudioClip safeOpenClip;

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
            audioSource.PlayOneShot(correctInputClip);
            onRightInput.Invoke();
            audioSource.PlayOneShot(safeOpenClip);
            Debug.Log("The safe has been opened");
        }
        else
        {
            audioSource.PlayOneShot(wrongInputClip);
            Debug.Log(currentCode.ToString() + " is the wrong code");
        }

        ClearCode();
    }
}
