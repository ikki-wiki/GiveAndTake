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
    private float defaultScore = 0f;
    private float scoreIncrement = 100f; // Default score increment amount
    private float score = 0f; // Current score value
    public string sceneToLoad;

    public void Start()
    {
        // Initialize UI elements and values based on PlayerPrefs
        InitializeUI();

        // Add listener to score toggle value change event
        scoreToggle.onValueChanged.AddListener(SetScoreEnabled);

        // Add listener to score input field value change event
        scoreInputField.onValueChanged.AddListener(OnScoreIncrementChanged);
    }

    void Update()
    {
        IncrementScore();
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
        scoreInputField.text = scoreIncrement.ToString();

        // Check the value of the score toggle from PlayerPrefs
        bool isScoreEnabled = PlayerPrefs.GetInt("ScoreEnabled", 1) == 1;
        scoreToggle.isOn = isScoreEnabled;

        // Set the active state of the score display based on the PlayerPrefs value
        displayScore.SetActive(isScoreEnabled);
    }

    // Method to handle the score increment value change event
    public void OnScoreIncrementChanged(string value)
    {
        float increment;
        if (float.TryParse(value, out increment))
        {
            // Update the score increment amount
            scoreIncrement = increment;
            scoreInputField.text = scoreIncrement.ToString();
        }
        else
        {
            Debug.LogWarning("Invalid input for score increment value.");
        }
    }

    // Method to increment the score
    public void IncrementScore()
    {
        VerifyWinCondition();

        if(Input.GetKeyDown(KeyCode.Space))
            score += scoreIncrement;
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void VerifyWinCondition()
    {
        if(score >= 3000)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
