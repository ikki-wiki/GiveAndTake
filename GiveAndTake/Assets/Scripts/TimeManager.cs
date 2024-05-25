using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Toggle timeToggle;
    public TMP_InputField timeInputField;
    public List<Text> timeTextList;
    public GameObject displayTime;
    private Coroutine timerCoroutine;
    public string sceneToLoad;
    public float defaultTime = 180f;
    private float timer;
    public bool shouldSceneLoad;
    public float RemainingTime
    {
        get
        {
            return timer;
        }
    }

    public void Start()
    {
        // Initialize UI elements and values based on PlayerPrefs
        InitializeUI();

        // Add listener to time input field value change event
        timeInputField.onEndEdit.AddListener(OnTimeInputValueChanged);

        // Add listener to time toggle value change event
        timeToggle.onValueChanged.AddListener(SetTimeEnabled);
    }

    public void SetTimeEnabled(bool isEnabled)
    {
        PlayerPrefs.SetInt("TimeEnabled", isEnabled ? 1 : 0);
        PlayerPrefs.Save();

        displayTime.SetActive(isEnabled);
        timeInputField.text = FormatTime(GetTimeDuration(defaultTime));

        if (isEnabled)
        {
            StartTimer();
        }
        else
        {
            StopTimer();
        }
    }

    // Method to start the timer
    void StartTimer()
    {
        if (timerCoroutine == null)
        {
            float duration = PlayerPrefs.GetFloat("TimeDuration", defaultTime);
            timerCoroutine = StartCoroutine(CountdownTimer(duration));
        }
        else
        {
            Debug.LogWarning("Timer is already running.");
        }
    }

    // Method to stop the timer
    void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    // Coroutine to count down the timer
    IEnumerator CountdownTimer(float duration)
    {
        timer = duration;

        while (timer > 0)
        {
            // Convert remaining time to minutes and seconds
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            // Update the timer text with the formatted time
            foreach (Text timeText in timeTextList)
                timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        // Timer has reached zero
        if (shouldSceneLoad)
            SceneManager.LoadScene(sceneToLoad);
    }

    // Method called when the value of the time input field changes
    void OnTimeInputValueChanged(string value)
    {
        float timeValue = ParseTime(value);
        if (timeValue >= 0)
        {
            SetTimeDuration(timeValue);
            // Don't update the timeInputField text here to avoid recursive value change events
        }
        else
        {
            Debug.LogWarning("Invalid input for time value.");
            // Optionally reset to the last valid time
            timeInputField.text = FormatTime(GetTimeDuration(defaultTime));
        }
    }

    public void InitializeUI()
    {
        timeToggle.isOn = GetTimeEnabled();
        timeInputField.gameObject.SetActive(true);
        timeInputField.text = FormatTime(GetTimeDuration(defaultTime));
        displayTime.SetActive(timeToggle.isOn);

        if (timeToggle.isOn)
        {
            StartTimer();
        }
    }

    public bool GetTimeEnabled()
    {
        return PlayerPrefs.GetInt("TimeEnabled", 0) == 1;
    }

    public void SetTimeDuration(float duration)
    {
        PlayerPrefs.SetFloat("TimeDuration", duration);
        PlayerPrefs.Save();
    }

    public float GetTimeDuration(float defaultDuration)
    {
        return PlayerPrefs.GetFloat("TimeDuration", defaultDuration);
    }

    // Helper method to format time as "MM:SS"
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Helper method to parse "MM:SS" format time
    private float ParseTime(string timeString)
    {
        string[] timeParts = timeString.Split(':');
        if (timeParts.Length == 2)
        {
            int minutes;
            int seconds;
            if (int.TryParse(timeParts[0], out minutes) && int.TryParse(timeParts[1], out seconds))
            {
                if (seconds < 60)
                {
                    return minutes * 60 + seconds;
                }
            }
        }
        else if (timeParts.Length == 1)
        {
            int minutes;
            if (int.TryParse(timeParts[0], out minutes))
            {
                return minutes * 60;
            }
        }
        return -1; // Return -1 if parsing fails
    }
}
