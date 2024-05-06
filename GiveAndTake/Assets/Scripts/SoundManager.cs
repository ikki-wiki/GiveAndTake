using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject with AudioListener component
    public Toggle soundToggle; // Reference to the sound toggle UI element

    void Start()
    {
        // Initialize toggle state based on sound setting
        InitializeUI();

        // Add listener to toggle value change event
        soundToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Method called when the toggle value changes
    void OnToggleValueChanged(bool isSoundEnabled)
    {
        // Update sound setting based on toggle state
        SetSoundEnabled(isSoundEnabled);
    }

    public void SetSoundEnabled(bool isEnabled)
    {
        PlayerPrefs.SetInt("SoundEnabled", isEnabled ? 1 : 0);
        PlayerPrefs.Save();

        if (targetObject != null)
        {
            AudioListener audioListener = targetObject.GetComponent<AudioListener>();
            if (audioListener != null)
            {
                audioListener.enabled = isEnabled;
            }
        }
    }

    public bool GetSoundEnabled()
    {
        return PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
    }

    public void InitializeUI()
    {
        soundToggle.isOn = GetSoundEnabled();
        targetObject.GetComponent<AudioListener>().enabled = soundToggle.isOn;
    }
}
