using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaveGame : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LeaveGame()
    {
        audioSource.Play();
        Application.Quit();

    }

}
