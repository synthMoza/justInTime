using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class DiaryController : MonoBehaviour
{
    private List<string> hints = new List<string>();

    [SerializeField]
    private GameObject prefabObj;
    [SerializeField]
    private Transform parentObj;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip openDiaryClip;
    [SerializeField]
    private AudioClip closeDiaryClip;

    [SerializeField]
    private Text attemptText;
    private int attempt;
    
    private bool isOpened;
    public UnityEvent onOpen;
    public UnityEvent onClose;

    private int noteCount = 0;
    private float offset = 4f;
    private char noteSuffix = '·';


    public void AddNote(string note)
    {
        if (hints.Contains(note))
            return;
        
        GameObject newObj = Instantiate(prefabObj, parentObj);
        Transform transformObj = newObj.GetComponent<Transform>();
        
        if (!transformObj)
        {
            Debug.Log("Can't get transform component");
            return;
        }

        transformObj.position = new Vector3(transformObj.position.x, transformObj.position.y - noteCount * offset, transformObj.position.z);
        noteCount++;

        Text textObj = newObj.GetComponent<Text>();
        if (!textObj)
        {
            Debug.Log("Can't get text component");
            return;
        }

        hints.Add(note);
        textObj.text = noteSuffix + note;
    }

    void OnEnable()
    {
        int count = PlayerPrefs.GetInt("hints_size", 0);
        for (int i = 0; i < count; ++i)
            AddNote(PlayerPrefs.GetString("hint_" + i));
        
        Debug.Log("check");
        attempt = PlayerPrefs.GetInt("attempt", 0);
        if (attempt == 0)
            PlayerPrefs.SetInt("attempt", attempt);

        attempt += 1;
        attemptText.text = "Attempt: " + attempt;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("hints_size", hints.Count);
        for (int i = 0; i < hints.Count; ++i)
            PlayerPrefs.SetString("hint_" + i, hints[i]);
        
        PlayerPrefs.SetInt("attempt", attempt);
        PlayerPrefs.Save();
    }

    public void ChangeState()
    {
        isOpened = !isOpened;

        if (isOpened)
        {
            audioSource.PlayOneShot(openDiaryClip);
            onOpen.Invoke();
        }
        else
        {
            audioSource.PlayOneShot(closeDiaryClip);
            onClose.Invoke();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChangeState();
        }
    }
}
