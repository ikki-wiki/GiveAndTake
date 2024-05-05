using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public GameObject targetObject; 
    public Toggle soundToggle; 
    public Toggle timeToggle; 
    public Toggle scoreToggle; 
    public TMP_InputField timeInputField; 
    public Text scoreText; 
    public Text timeText; 
    public GameObject displayTime; 
    public GameObject displayScore; 
    public float defaultTime = 180f; 

    private int score = 0; 
    private Coroutine timerCoroutine;

    void Start()
    {
        // Initialize UI elements and values based on PlayerPrefs
        InitializeUI();

        // Add listeners to toggle value change events
        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        timeToggle.onValueChanged.AddListener(OnTimeToggleChanged);
        scoreToggle.onValueChanged.AddListener(OnScoreToggleChanged);

        // Add listener to time input field value change event
        timeInputField.onValueChanged.AddListener(OnTimeInputValueChanged);
    }

    // Method called when the sound toggle value changes
    void OnSoundToggleChanged(bool isSoundEnabled)
    {
        PlayerPrefs.SetInt("SoundEnabled", isSoundEnabled ? 1 : 0);
        PlayerPrefs.Save();

        if (targetObject != null)
        {
            AudioListener audioListener = targetObject.GetComponent<AudioListener>();
            if (audioListener != null)
            {
                audioListener.enabled = isSoundEnabled;
            }
        }
    }

    // Method called when the score toggle value changes
    void OnScoreToggleChanged(bool isScoreEnabled)
    {
        PlayerPrefs.SetInt("ScoreEnabled", isScoreEnabled ? 1 : 0);
        PlayerPrefs.Save();
        scoreText.gameObject.SetActive(isScoreEnabled);
        displayScore.SetActive(isScoreEnabled);
    }

    // Method called when the time toggle value changes
    void OnTimeToggleChanged(bool isTimeEnabled)
    {
        PlayerPrefs.SetInt("TimeEnabled", isTimeEnabled ? 1 : 0);
        PlayerPrefs.Save();
        timeInputField.gameObject.SetActive(isTimeEnabled);
        displayTime.SetActive(isTimeEnabled);

        // Show or hide the score toggle based on the state of the time toggle
        scoreToggle.gameObject.SetActive(isTimeEnabled);
        displayScore.SetActive(isTimeEnabled && scoreToggle.isOn);

        if (isTimeEnabled)
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
        int startingScore = 1000;
        float scorePerSecond = startingScore / duration;

        while (timer > 0)
        {
            // Convert remaining time to minutes and seconds
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            // Update the timer text with the formatted time
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Update the score based on the remaining time
            int updatedScore = Mathf.FloorToInt(startingScore - (scorePerSecond * (duration - timer)));
            scoreText.text = updatedScore.ToString();

            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        // Timer has reached zero, do something (e.g., end game, trigger event, etc.)
        Debug.Log("Timer has reached zero!");
        SceneManager.LoadScene("MinigameContasEquivalentes");
    }

    // Method to initialize UI elements and values based on PlayerPrefs
    void InitializeUI()
    {
        soundToggle.isOn = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        if(!soundToggle.isOn)
        {
            targetObject.GetComponent<AudioListener>().enabled = false;
        }

        timeToggle.isOn = PlayerPrefs.GetInt("TimeEnabled", 0) == 1;
        if(!timeToggle.isOn)
        {
            displayTime.SetActive(false);
            scoreToggle.gameObject.SetActive(false); // Hide the score toggle when the time toggle is off
            displayScore.SetActive(false);
        } 
        else
        {
            StartTimer();
            scoreToggle.gameObject.SetActive(true); // Hide the score toggle when the time toggle is off
        }

        scoreToggle.isOn = PlayerPrefs.GetInt("ScoreEnabled", 0) == 1;
        if(!scoreToggle.isOn)
        {
            displayScore.SetActive(false);
        } else if(timeToggle.isOn)
        {
            displayScore.SetActive(true);
        }

        timeInputField.text = PlayerPrefs.GetFloat("TimeDuration", defaultTime).ToString();
        timeInputField.gameObject.SetActive(timeToggle.isOn);
        scoreText.gameObject.SetActive(scoreToggle.isOn);
        displayTime.SetActive(timeToggle.isOn);
        displayScore.SetActive(scoreToggle.isOn);
    }

    // Method called when the value of the time input field changes
    void OnTimeInputValueChanged(string value)
    {
        float timeValue;
        if (float.TryParse(value, out timeValue))
        {
            // Save the time value to PlayerPrefs
            PlayerPrefs.SetFloat("TimeDuration", timeValue);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogWarning("Invalid input for time value.");
        }
    }
}
