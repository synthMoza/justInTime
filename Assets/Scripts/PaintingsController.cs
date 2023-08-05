using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingsController : MonoBehaviour
{
    [SerializeField]
    private HintsManager hintsManager;
    [SerializeField]
    private DiaryController diaryController;

    [SerializeField]
    private Painting leftPainting;
    [SerializeField]
    private Painting rightPainting;

    [SerializeField]
    private DressersController dressersController;

    private bool waPlayerNotified = false;

    public void TryInteract(Painting painting)
    {
        if (!waPlayerNotified)
        {
            hintsManager.ShowHint("There is a greek letter on this painting, but it is not looking in the right direction.");
            diaryController.AddNote("Paintings have rotated greek letters on them.");
            
            waPlayerNotified = true;
        }
        else
        {
            painting.Rotate();
        }

        if (leftPainting.IsRightPosition() && rightPainting.IsRightPosition())
            dressersController.UnlockDressers();
        else
            dressersController.LockDressers();
    }
}
