using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
