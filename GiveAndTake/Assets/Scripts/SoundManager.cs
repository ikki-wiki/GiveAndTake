using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject containing the AudioListener
    public Toggle soundToggle; // Reference to the Toggle UI element

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target GameObject is not assigned!");
            return;
        }

        // Initialize the toggle state based on the current sound state
        AudioListener audioListener = targetObject.GetComponent<AudioListener>();
        if (audioListener != null)
        {
            soundToggle.isOn = audioListener.enabled;
        }
        else
        {
            Debug.LogError("Target GameObject does not have an AudioListener component!");
        }

        // Add listener to toggle's value change event
        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
    }

    // Method called when the toggle value changes
    void OnSoundToggleChanged(bool isSoundEnabled)
    {
        Debug.Log("Sound enabled: " + isSoundEnabled);
        // Enable or disable the audio listener based on the toggle value
        AudioListener audioListener = targetObject.GetComponent<AudioListener>();
        if (audioListener != null)
        {
            audioListener.enabled = isSoundEnabled;
        }
        else
        {
            Debug.LogError("Target GameObject does not have an AudioListener component!");
        }
    }
}
