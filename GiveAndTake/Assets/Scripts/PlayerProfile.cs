[System.Serializable]
public class PlayerProfile
{
    public string username;
    public float score;

    public static PlayerProfile currentProfile;

    public PlayerProfile(string username, float score)
    {
        this.username = username;
        this.score = score;
    }

    public PlayerProfile(float score)
    {
        this.score = score;
    }
}
