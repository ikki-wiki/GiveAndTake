using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarsManager : MonoBehaviour
{
    public GameObject star;
    public GameObject star2;
    public GameObject star3;
    public Text timeText;
    public Text pointsText;
    private bool timeTextIsActive = false;
    private float initialTime;
    private float time3Stars;
    private float time2Stars;

    public void Update()
    {
        if (timeText.IsActive())
        {
            if (!timeTextIsActive)
            {
                initialTime = ParseTime(timeText.text);
                time3Stars = initialTime * 0.75f; // 3/4 do tempo inicial, depois podemos mudar nao sei
                time2Stars = initialTime * 0.5f;  // metade do tempo inicial
                timeTextIsActive = true;
            }
            
            if(pointsText.IsActive())
            {  
                CheckStars();
            }
            else
            {
                disableStars();
            }
        }
        else
        {
            if (timeTextIsActive)
            {
                timeTextIsActive = false;
            }
            disableStars();
        }
    }

    public void disableStars()
    {
        star.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    public void CheckStars()
    {
        float remainingTime = ParseTime(timeText.text);
        if (remainingTime >= time3Stars)
        {
            star.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (remainingTime >= time2Stars)
        {
            star.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else
        {
            star.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

    private float ParseTime(string timeString)
    {
        string[] timeParts = timeString.Split(':');
        if (timeParts.Length == 2)
        {
            int minutes;
            int seconds;
            if (int.TryParse(timeParts[0], out minutes) && int.TryParse(timeParts[1], out seconds))
            {
                return minutes * 60 + seconds;
            }
        }
        return -1;
    }
}
