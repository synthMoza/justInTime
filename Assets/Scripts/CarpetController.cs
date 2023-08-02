using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetController : MonoBehaviour
{
    [SerializeField]
    private Sprite openCarpetSprite;

    public void OpenCarpet(MapController mapController)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = openCarpetSprite;
        mapController.ChangeLeftWindowLightSprite();
    }
}
