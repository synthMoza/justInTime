using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;
    
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private GameObject LoseScreen;
    [SerializeField]
    private GameObject WinScreen;
    
    [SerializeField]
    private AudioSource radioAudioSource;
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private PauseManager pauseManager;

    void TurnOffGameAssets()
    {
        timeManager.StopTimer();
        pauseManager.ChangePhysicsPause();
        radioAudioSource.volume = 0;
    }

    IEnumerator GameEndRoutine()
    {
        TurnOffGameAssets();

        playerAnimator.SetTrigger("Death");
        audioSource.PlayOneShot(deathSound);
        yield return new WaitForSecondsRealtime(2f);

        pauseManager.transform.gameObject.SetActive(false);
        LoseScreen.SetActive(true);
    }

    public void WinRoutine()
    {
        TurnOffGameAssets();
        WinScreen.SetActive(true);
    }

    public void LoseRoutine()
    {
        StartCoroutine(GameEndRoutine());
    }
}
