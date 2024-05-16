using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Toggle scoreToggle;
    public TMP_InputField scoreInputField;
    public Text scoreText; 
    public GameObject displayScore; 
    private float maxScore = 1000f;
    private float score = 0f; // Current score value

    // Reference to the TimeManager script
    public TimeManager timeManager;

    public void Start()
    {
        // Initialize UI elements and values based on PlayerPrefs
        InitializeUI();

        score = maxScore;

        // Add listener to score toggle value change event
        scoreToggle.onValueChanged.AddListener(SetScoreEnabled);

        // Add listener to score input field value change event
        scoreInputField.onValueChanged.AddListener(OnBaseScoreChanged);
    }

    void Update()
    {
        VerifyIfTimerIsOn();

        // Increment the score based on the remaining time
        DecreaseScore();

        // Update the score text based on the current score value
        UpdateScoreText();
    }

    public void SetScoreEnabled(bool isEnabled)
    {
        PlayerPrefs.SetInt("ScoreEnabled", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
        
        displayScore.SetActive(isEnabled);
    }

    public void InitializeUI()
    {
        // Set the score input field text to the default increment amount
        scoreInputField.text = maxScore.ToString();

        // Check the value of the score toggle from PlayerPrefs
        bool isScoreEnabled = PlayerPrefs.GetInt("ScoreEnabled", 1) == 1;
        scoreToggle.isOn = isScoreEnabled;

        // Set the active state of the score display based on the PlayerPrefs value
        displayScore.SetActive(isScoreEnabled);
    }

    // Method to handle the score increment value change event
    public void OnBaseScoreChanged(string value)
    {
        float currentBaseScore;
        if (float.TryParse(value, out currentBaseScore))
        {
            // Update the score increment amount
            maxScore = currentBaseScore;
            scoreInputField.text = maxScore.ToString();
        }
        else
        {
            Debug.LogWarning("Invalid input for score increment value.");
        }
    }

    // Method to increment the score
    public void DecreaseScore()
    {
        // Get the remaining time from the TimeManager script
        float remainingTime = timeManager.RemainingTime;

        // Calculate the score decrease rate based on the remaining time
        float decreaseRate = maxScore / timeManager.GetTimeDuration(timeManager.defaultTime);

        // Decrease the score proportionally to the remaining time
        score = maxScore - (decreaseRate * (timeManager.GetTimeDuration(timeManager.defaultTime) - remainingTime));
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        // Round the score to the nearest integer
        int roundedScore = Mathf.RoundToInt(score);

        // Update the score text with the rounded score
        scoreText.text = roundedScore.ToString();
    }

    public float GetScore()
    {
        return score;
    }

    public void VerifyIfTimerIsOn()
    {
        if(timeManager.timeToggle.isOn){
            scoreToggle.gameObject.SetActive(true);
            scoreInputField.gameObject.SetActive(true);
            if(scoreToggle.isOn){
                displayScore.SetActive(true);
            }
        } else {
            scoreToggle.gameObject.SetActive(false);
            scoreInputField.gameObject.SetActive(false);
            displayScore.SetActive(false);
        }
    }

}
