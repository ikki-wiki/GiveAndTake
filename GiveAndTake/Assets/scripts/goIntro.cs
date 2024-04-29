using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goIntro : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayIntro()
    {
        audioSource.Play();
        SceneManager.LoadSceneAsync(5);
    }
}
