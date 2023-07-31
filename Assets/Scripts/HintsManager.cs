using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HintsManager : MonoBehaviour
{
    [SerializeField]
    private Text subtitlesText;
    public float subtitlesDuration = 5f;

    public void ShowHint(string hint)
    {
        StartCoroutine(ShowHintCoroutine(hint));
    }

    IEnumerator ShowHintCoroutine(string hint)
    {
        subtitlesText.text = hint;
        yield return new WaitForSecondsRealtime(subtitlesDuration);
        if (subtitlesText.text == hint) // yes, this is a bad idea
            subtitlesText.text = "";
    }
}
