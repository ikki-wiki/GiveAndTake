using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerProfile.currentProfile = new PlayerProfile(0);
    }

    public void PlayGame()
    {
        audioSource.Play();
        SceneManager.LoadSceneAsync(1);
    }
}
