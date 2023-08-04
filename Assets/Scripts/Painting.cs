using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip rotateClip;

    [SerializeField]
    private Sprite[] positionSprites;
    [SerializeField]
    private int rightPositionIdx;

    private int positionIdx = 0;

    public void Rotate()
    {
        positionIdx++;
        if (positionIdx >= positionSprites.Length)
            positionIdx = 0;
        
        gameObject.GetComponent<SpriteRenderer>().sprite = positionSprites[positionIdx];
        audioSource.PlayOneShot(rotateClip);
    }

    public bool IsRightPosition()
    {
        return positionIdx == rightPositionIdx;
    }
}
