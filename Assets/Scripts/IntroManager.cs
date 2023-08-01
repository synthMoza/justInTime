using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public float waitTime;

    void Start()
    {
        StartCoroutine(MakeIntro());       
    }

    IEnumerator MakeIntro()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load game scene
    }
}
