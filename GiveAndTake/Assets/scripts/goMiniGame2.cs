using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goMiniGame2 : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame2()
    {
        audioSource.Play();
        PlayerProfile.currentProfile.score = 0;
        SceneManager.LoadSceneAsync(6);
    }
}
