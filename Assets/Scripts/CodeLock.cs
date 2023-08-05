using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    private string secretCode;
    private string currentCode;

    [SerializeField]
    private GameObject interactableObj;
    [SerializeField]
    private GameObject codeLockScreen;
    [SerializeField]
    private PauseManager pauseManager;
    
    [SerializeField]
    private HintsManager hintsManager;
    [SerializeField]
    private DiaryController diaryController;

    [SerializeField]
    private Sprite openSafeSprite;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip correctInputClip;
    [SerializeField]
    private AudioClip wrongInputClip;
    [SerializeField]
    private AudioClip safeOpenClip;

    void Start()
    {
        // Check if we have generated secret code before
        secretCode = PlayerPrefs.GetString("safe_secret_code", ""); // not a good idea to store secret code lkiek that but screw it
        if (secretCode == "")
        {
            // generate a new code
            secretCode = Random.Range(1000, 9999).ToString();
            PlayerPrefs.SetString("safe_secret_code", secretCode);
        }
        Debug.Log("secret_code is " + secretCode);
    }

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
            audioSource.PlayOneShot(safeOpenClip);
            gameObject.GetComponent<SpriteRenderer>().sprite = openSafeSprite;
            
            int timing = PlayerPrefs.GetInt("red_button_timing");
            string timingStr = (timing / 60).ToString() + ":" + (timing % 60).ToString();
            hintsManager.ShowHint("There is a note in the safe, and it says: \"Red Button " + timingStr + "\". Is it connected with the timer?");
            diaryController.AddNote("\"Red Button " + timingStr + "\" - note in the safe says");
            Debug.Log("The safe has been opened");
            
            interactableObj.SetActive(false);
            codeLockScreen.SetActive(false);
            pauseManager.ChangePhysicsPause();
        }
        else
        {
            audioSource.PlayOneShot(wrongInputClip);
            Debug.Log(currentCode.ToString() + " is the wrong code");
        }

        ClearCode();
    }
}
