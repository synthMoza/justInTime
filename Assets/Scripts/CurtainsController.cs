using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainsController : MonoBehaviour
{
    [SerializeField]
    private Sprite curtainsOpen;
    [SerializeField]
    private Sprite curtainsClosed;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip curtainsOpenClip;
    [SerializeField]
    private AudioClip curtainsCloseClip;

    private bool isOpen = true;

    public void SwitchState()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = curtainsOpen;
            audioSource.PlayOneShot(curtainsOpenClip);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = curtainsClosed;
            audioSource.PlayOneShot(curtainsCloseClip);
        }
    }
}
