using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CreateProfile : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public Button createProfileButton;

    private List<PlayerProfile> profiles;

    void Start()
    {
        createProfileButton.onClick.AddListener(CreateNewProfile);
        profiles = ProfileManager.instance.GetProfiles();
    }
    public void CreateNewProfile()
    {
        string username = usernameInput.text;

         if (profiles.Find(profile => profile.username == username) != null)
        {
            Debug.Log("A profile with the username '" + username + "' already exists.");
            return;
        }

        if (!string.IsNullOrEmpty(username))
        {
            ProfileManager.instance.AddProfile(username);
            profiles = ProfileManager.instance.GetProfiles();
            Debug.Log("Profile created with username: " + username);
            Debug.Log("Usernames: " + string.Join(", ", profiles.ConvertAll(profile => profile.username).ToArray()));
            usernameInput.text = "";
            SceneManager.LoadScene("SelectProfileMenu");
        }
        else
        {
            Debug.Log("Username cannot be empty.");
        }
    }
}
