using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject[] toDeactivateobjs;

    [SerializeField]
    private AudioSource audioSource;
    // [SerializeField]
    // private AudioSource mainAudioSource;
    [SerializeField]
    private AudioClip fadeOutClip;
    [SerializeField]
    private AudioClip epicSwitchClip;

    public void FadeToLevel(int lvlIdx)
    {
        StartCoroutine(BeforeGameRoutine());
    }

    public IEnumerator BeforeGameRoutine()
    {
        foreach (var obj in toDeactivateobjs)
            obj.SetActive(false);
        
        audioSource.Stop();
        audioSource.PlayOneShot(epicSwitchClip);
        audioSource.PlayOneShot(fadeOutClip);
        yield return new WaitForSecondsRealtime(1.5f);
        
        animator.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
