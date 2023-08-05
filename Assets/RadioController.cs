using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;
    
    [SerializeField]
    private HintsManager hintsManager;
    [SerializeField]
    private DiaryController diaryController;

    [SerializeField]
    private AudioSource audioSource;

    private bool isRadioPlaying;

    public void Interact()
    {
        if (playerManager.hasRadioScheme)
        {
            // change radio state
            isRadioPlaying = !isRadioPlaying;
            if (isRadioPlaying)
            {
                // play track
                audioSource.Play();
            }
            else
            {
                // stop it please
                audioSource.Stop();
            }
        }
        else
        {
            // hint
            diaryController.AddNote("Radio can be fixed with the electrical circuit.");
            hintsManager.ShowHint("This radio seems to be broken. Maybe I can fix it if find some scheme of it.");
        }
    }
}
