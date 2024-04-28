using UnityEngine;
using System.Collections.Generic;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;

    private List<PlayerProfile> profiles = new List<PlayerProfile>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadProfiles();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadProfiles()
    {
        // Load profile data from PlayerPrefs or other storage
        int profileCount = PlayerPrefs.GetInt("ProfileCount", 0);
        for (int i = 0; i < profileCount; i++)
        {
            string profileName = PlayerPrefs.GetString("Profile_" + i + "_Name");
            int score = PlayerPrefs.GetInt("Profile_" + i + "_Score");
            profiles.Add(new PlayerProfile(profileName, score));
        }
        Debug.Log("Usernames: " + string.Join(", ", profiles.ConvertAll(profile => profile.username).ToArray()));
    }

    public List<PlayerProfile> GetProfiles()
    {
        return profiles;
    }

    public void AddProfile(string username)
    {
        profiles.Add(new PlayerProfile(username, 0));
        SaveProfiles();
    }


    public void RemoveProfile(PlayerProfile profile)
    {
        profiles.Remove(profile);
        SaveProfiles();
    }

    void SaveProfiles()
    {
        // Save profile data to PlayerPrefs or other storage
        PlayerPrefs.SetInt("ProfileCount", profiles.Count);
        for (int i = 0; i < profiles.Count; i++)
        {
            PlayerPrefs.SetString("Profile_" + i + "_Name", profiles[i].username);
            PlayerPrefs.SetInt("Profile_" + i + "_Score", profiles[i].score);
        }
        PlayerPrefs.Save();
    }

}
