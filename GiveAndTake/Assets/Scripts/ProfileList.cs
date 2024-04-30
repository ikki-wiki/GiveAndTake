using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ProfileList : MonoBehaviour
{
    public GameObject profilePrefab; // Prefab for displaying a single profile
    public Transform profileListParent; // Parent transform for instantiated profile objects
    private List<PlayerProfile> profiles;
    private List<GameObject> profileObjects = new List<GameObject>(); // List to store instantiated profile UI objects
    public TMP_Text noProfilesText;

    void Start()
    {
        UpdateProfileListUI();
    }

    void UpdateProfileListUI()
    {
        profiles = ProfileManager.instance.GetProfiles();
        float yPosition = profilePrefab.transform.position.y;

        foreach (GameObject profileObject in profileObjects)
        {
            Destroy(profileObject);
        }
        profileObjects.Clear(); // Clear the list of profile UI objects

        // Display each player profile in the UI
        foreach (PlayerProfile profile in profiles)
        {
            GameObject profileObject = Instantiate(profilePrefab, profileListParent);
            profileObject.transform.SetParent(profileListParent, false);
            profileObject.SetActive(true);

            TextMeshProUGUI usernameText = profileObject.transform.Find("Username").GetComponent<TextMeshProUGUI>();
            usernameText.text = profile.username;
            usernameText.enabled = true;

            Button selectButton = profileObject.transform.Find("Select").GetComponent<Button>();
            Image selectButtonImage = profileObject.transform.Find("Select").GetComponent<Image>();
            selectButton.enabled = true;
            selectButtonImage.enabled = true;
            selectButton.onClick.AddListener(() => SelectProfile(profile));

            Button removeButton = profileObject.transform.Find("Remove").GetComponent<Button>();
            Image removeButtonImage = profileObject.transform.Find("Remove").GetComponent<Image>();
            removeButton.enabled = true;
            removeButtonImage.enabled = true;
            removeButton.onClick.AddListener(() => DeleteProfile(profile));

            profileObject.transform.position = new Vector3(profileObject.transform.position.x, yPosition, 0);
            yPosition -= 80f;

            // Add the instantiated profile UI object to the list
            profileObjects.Add(profileObject);
        }

        if(profiles.Count <= 0 || profileObjects.Count <= 0)
        {
            noProfilesText.enabled = true;
            TextMeshProUGUI noProfilesTextComponent = noProfilesText.GetComponent<TextMeshProUGUI>();
            noProfilesTextComponent.enabled = true;
        } else
        {
            noProfilesText.enabled = false;
            TextMeshProUGUI noProfilesTextComponent = noProfilesText.GetComponent<TextMeshProUGUI>();
            noProfilesTextComponent.enabled = false;
        }
    } 

    void SelectProfile(PlayerProfile profile)
    {
        SelectedProfile.SelectedProfileInstance = profile;
        Debug.Log("Selected profile: " + SelectedProfile.SelectedProfileInstance.username);
    }

    void DeleteProfile(PlayerProfile profile)
    {
        ProfileManager.instance.RemoveProfile(profile);
        Debug.Log("Deleted profile: " + profile.username);
        UpdateProfileListUI();
    }
}
