using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HintsManager : MonoBehaviour
{
    private List<string> hints = new List<string>();

    [SerializeField]
    private Text subtitlesText;
    public float subtitlesDuration = 5f;

    void Awake()
    {
        StartCoroutine(ShowHintCoroutine());
    }

    public void AddHintToQueue(string hint)
    {
        hints.Add(hint);
    }

    IEnumerator ShowHintCoroutine()
    {
        WaitForSeconds waitTime = new WaitForSeconds(subtitlesDuration);

        while (true)
        {
            int count = hints.Count;
            if (count > 0)
            {
                string hint = hints[count - 1];

                subtitlesText.text = hint;
                yield return new WaitForSeconds(subtitlesDuration);
                subtitlesText.text = "";

                hints.RemoveAt(count - 1);
            }
        }
        
    }
}
