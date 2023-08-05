using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressersController : MonoBehaviour
{
    [SerializeField]
    private GameObject closedDressers;
    [SerializeField]
    private GameObject openDressers;

    public void UnlockDressers()
    {
        closedDressers.SetActive(false);
        openDressers.SetActive(true);
    }

    public void LockDressers()
    {
        closedDressers.SetActive(true);
        openDressers.SetActive(false);
    }
}
