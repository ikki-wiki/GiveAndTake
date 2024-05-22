using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    public GameObject star;
    public GameObject star2;
    public GameObject star3;
    public Text timeText;

    //quero estar sempre a verificar se o timeText está ativo, e se tiver quero que as 3 estrelas apareçam, e ao atingir 3/4 do tempo, quero que apenas duas estrelas apareças, e ao atingir 1/4 do tempo, quero que esteja apenas uma estrela, se chegar a 0 quero que não apareça nenhuma estrela. Nota que quero guardar o tempo estipulado para o jogo, e quero que as estrelas apareçam consoante o tempo que foi estipulado.

    public void Start()
    {
        // Initialize UI elements and values based on PlayerPrefs
        InitializeUI();
    }

    public void InitializeUI()
    {
        // Add listener to time text value change event
        timeText.onValueChanged.AddListener(OnTimeValueChanged);
    }

    public void OnTimeValueChanged(string time)
    {
        // Get the time value
        float GameTime = float.Parse(time);

        // Get the time value in seconds
        float timeInSeconds = GetTimeInSeconds(GameTime);

        // Get the time value in minutes
        float timeInMinutes = GetTimeInMinutes(timeValue);
    }

    public float GetTimeInSeconds(float timeValue)
    {
        return timeValue;
    }

    public float GetTimeInMinutes(float timeValue)
    {
        return timeValue / 60;
    }

    public void ShowStars(int stars)
    {
        switch (stars)
        {
            case 0:
                star.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                break;
            case 1:
                star.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                break;
            case 2:
                star.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
                break;
            case 3:
                star.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                break;
        }
    }

    public void Update()
    {
        // Get the time value
        float timeValue = float.Parse(timeText.text);

        // Get the time value in seconds
        float timeInSeconds = GetTimeInSeconds(timeValue);

        // Get the time value in minutes
        float timeInMinutes = GetTimeInMinutes(timeValue);

        // Show stars based on the time value
        if (timeInSeconds == 0)
        {
            ShowStars(0);
        }
        else if (timeInSeconds <= timeInMinutes / 4)
        {
            ShowStars(1);
        }
        else if (timeInSeconds <= timeInMinutes / 2)
        {
            ShowStars(2);
        }
        else
        {
            ShowStars(3);
        }
    }
}
