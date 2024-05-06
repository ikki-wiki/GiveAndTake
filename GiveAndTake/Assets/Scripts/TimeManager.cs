using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Toggle timeToggle;
    public TMP_InputField timeInputField; 
    public Text timeText; 
    public GameObject displayTime; 
    private Coroutine timerCoroutine;
    public string sceneToLoad;
    public float defaultTime = 180f;

    public void Start()
    {
        // Initialize UI elements and values based on PlayerPrefs
        InitializeUI();

        // Add listener to time input field value change event
        timeInputField.onValueChanged.AddListener(OnTimeInputValueChanged);

        // Add listener to time toggle value change event
        timeToggle.onValueChanged.AddListener(SetTimeEnabled);
    }
    public void SetTimeEnabled(bool isEnabled)
    {
        PlayerPrefs.SetInt("TimeEnabled", isEnabled ? 1 : 0);
        PlayerPrefs.Save();

        displayTime.SetActive(isEnabled);
        timeInputField.text = GetTimeDuration(defaultTime).ToString();

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
        float timer = duration;

        while (timer > 0)
        {
            // Convert remaining time to minutes and seconds
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            // Update the timer text with the formatted time
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        // Timer has reached zero
        SceneManager.LoadScene(sceneToLoad);
    }

    // Method called when the value of the time input field changes
    void OnTimeInputValueChanged(string value)
    {
        float timeValue;
        if (float.TryParse(value, out timeValue))
        {
            SetTimeDuration(timeValue);
            timeInputField.text = timeValue.ToString();
        }
        else
        {
            Debug.LogWarning("Invalid input for time value.");
        }
    }

    public void InitializeUI()
    {
        timeToggle.isOn = GetTimeEnabled();
        timeInputField.gameObject.SetActive(true);
        timeInputField.text = GetTimeDuration(defaultTime).ToString();
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
}

