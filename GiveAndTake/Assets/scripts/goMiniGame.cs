using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goMiniGame : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        audioSource.Play();
        PlayerProfile.currentProfile.score = 0;
        SceneManager.LoadSceneAsync(2);
    }

    public void PlayCompetitive()
    {
        Time.timeScale = 1.0f;
        audioSource.Play();
        SceneManager.LoadSceneAsync(9);
    }
    public void PlayCompetitiveIntro()
    {
        audioSource.Play();
        SceneManager.LoadSceneAsync(10);
    }

}
