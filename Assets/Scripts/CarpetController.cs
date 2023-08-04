using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetController : MonoBehaviour
{
    [SerializeField]
    private Sprite openCarpetSprite;

    [SerializeField]
    private GameObject noteObject;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip carpetSound;

    private bool isOpen;

    public void OpenCarpet(MapController mapController)
    {
        if (!isOpen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = openCarpetSprite;
            mapController.ChangeLeftWindowLightSprite();
            audioSource.PlayOneShot(carpetSound);
            noteObject.SetActive(true);
            
            isOpen = true;            
        }
    }
}
