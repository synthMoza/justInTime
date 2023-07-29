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
        subtitlesText.text = hint;
        StartCoroutine(ShowHintCoroutine());
    }

    IEnumerator ShowHintCoroutine()
    {
        yield return new WaitForSeconds(subtitlesDuration);
        subtitlesText.text = "";
    }
}
